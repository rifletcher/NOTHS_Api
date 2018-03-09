using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using NOTHS_Api.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Net;
using System.Threading.Tasks;
using System.Windows;

namespace NOTHS_Api.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private RelayCommand _callNothsApiCommand;

        public RelayCommand CallNothsApiCommand
        {
            get
            {
                return _callNothsApiCommand ?? (_callNothsApiCommand = new RelayCommand(
                           () =>
                           {
                               ExecuteCallNothsApiCommand();
                           }));
            }
        }
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
        }

        protected static string NothsUrl
        {
            get
            {
                try
                {
                    var configurationAppSettings = new System.Configuration.AppSettingsReader();
                    return (string)configurationAppSettings.GetValue("NOTHS_BASE_URL", typeof(string));
                }
                catch (Exception)
                {
                    return "https://www.notonthehighstreet.com";
                }
            }
        }

        private string _token;
        private int _offset = 0;
        private int _perPage = 10;
        private string _state = "accepted";
        private ObservableCollection<NOTHSOrder> _orderList = new ObservableCollection<NOTHSOrder>();

        public string Token
        {
            get => _token;
            set
            {
                _token = value;
                RaisePropertyChanged();
            }
        }

        public int Offset
        {
            get => _offset;
            set
            {
                _offset = value;
                RaisePropertyChanged();
            }
        }

        public int PerPage
        {
            get => _perPage;
            set
            {
                _perPage = value;
                RaisePropertyChanged();
            }
        }

        public string State
        {
            get => _state;
            set
            {
                _state = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<NOTHSOrder> OrderList
        {
            get => _orderList;
            set
            {
                _orderList = value;
                RaisePropertyChanged();
            }
        }
        public void ExecuteCallNothsApiCommand()
        {
            var client = new RestClient(NothsUrl);
            var request = new RestRequest("/api/v1/orders");
            List<NOTHSOrder> orders = new List<NOTHSOrder>();

            request.AddParameter("token", _token);
            request.AddParameter("offset", _offset);
            request.AddParameter("per_page", _perPage);
            request.AddParameter("state", _state);
            var response = client.Execute<GetOrdersResponse>(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                MessageBox.Show(string.Format("Error-> StatusCode: {0}, StatusDescription: {1}, ErrorMessage: {2}, Content: {3}",
                    response.StatusCode, response.StatusDescription, response.ErrorException));
            }
            else
            {
                int receivedOrders = response.Data.query.results;
                if (receivedOrders > 0)
                {
                    foreach (var item in response.Data.data)
                        OrderList.Add(item);
                }
            }
            return;
        }

    }
}