using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOTHS_Api.Model
{
    public class Query
    {
        public int results { get; set; }
        public int total { get; set; }
    }

    public class Currency
    {
        public int subunit_to_unit { get; set; }
        public string symbol { get; set; }
        public string html_entity { get; set; }
        public string iso_code { get; set; }
    }

    public class RemainingRefundAmount
    {
        public int cents { get; set; }
        public Currency currency { get; set; }
    }

    public class ExtraRefundAmount
    {
        public int cents { get; set; }
        public Currency currency { get; set; }
    }

    public class User
    {
        public string name { get; set; }
        public string telephone { get; set; }
        public string telephone_country_code { get; set; }
    }

    public class DeliveryAddress
    {
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string town { get; set; }
        public string post_code { get; set; }
        public string country { get; set; }
        public string county { get; set; }
    }

    public class DeliveryZone
    {
        public int id { get; set; }
        public string name { get; set; }
        public string zone_group { get; set; }
    }

    public class DeliveryService
    {
        public string name { get; set; }
        public string code { get; set; }
    }

    public class OrderTotal
    {
        public int cents { get; set; }
        public Currency currency { get; set; }
    }

    public class DeliveryTotal
    {
        public int cents { get; set; }
        public Currency currency { get; set; }
    }

    public class NOTHSMessage
    {
        public string body { get; set; }
        public string highlighted_body { get; set; }
        public string participant_name { get; set; }
        public string created_on_behalf_of { get; set; }
        public string participant_type { get; set; }
        public int participant_id { get; set; }
        public string participant_email { get; set; }
        public string participant_entity { get; set; }
        public string created_at { get; set; }
    }

    public class Enquiry
    {
        public long id { get; set; }
        public string state { get; set; }
        public string type { get; set; }
        public long order_id { get; set; }
        public string short_subject { get; set; }
        public bool flagged { get; set; }
        public bool flagged_by_partner { get; set; }
        public bool monitored { get; set; }
        public List<NOTHSMessage> messages { get; set; }
    }

    public class Option
    {
        public string name { get; set; }
        public string value { get; set; }
    }

    public class ListingTotalGross
    {
        public int cents { get; set; }
        public Currency currency { get; set; }
    }

    public class Image
    {
        public string micro_url { get; set; }
        public string mini_url { get; set; }
        public string thumb_url { get; set; }
        public string medium_url { get; set; }
        public string preview_url { get; set; }
        public string normal_url { get; set; }
    }

    public class Product
    {
        public long id { get; set; }
        public string sku { get; set; }
        public string title { get; set; }
        public bool personalisable { get; set; }
        public Image image { get; set; }
    }

    public class Item
    {
        public long id { get; set; }
        public string item_title { get; set; }
        public int quantity { get; set; }
        public List<Option> options { get; set; }
        public ListingTotalGross listing_total_gross { get; set; }
        public Product product { get; set; }
    }

    public class Link
    {
        public string rel { get; set; }
        public string method { get; set; }
        public string href { get; set; }
    }

    public class NOTHSOrder
    {
        public long id { get; set; }
        public string state { get; set; }
        public string confirm_by { get; set; }
        public string estimated_dispatch_at { get; set; }
        public string placed_at { get; set; }
        public string expired_at { get; set; }
        public string declined_at { get; set; }
        public string accepted_at { get; set; }
        public string dispatched_at { get; set; }
        public bool repeat_customer { get; set; }
        public string customer_expected_delivery_date { get; set; }
        public string number { get; set; }
        public bool dispatch_note_viewed { get; set; }
        public bool express { get; set; }
        public string partner_name { get; set; }
        public string delivery_recipient_name { get; set; }
        public bool international { get; set; }
        public bool dispatch_overdue { get; set; }
        public bool gift { get; set; }
        public string gift_message { get; set; }
        public string delivery_note { get; set; }
        public bool has_enquiry { get; set; }
        public string estimated_delivered_date { get; set; }
        public RemainingRefundAmount remaining_refund_amount { get; set; }
        public ExtraRefundAmount extra_refund_amount { get; set; }
        public User user { get; set; }
        public DeliveryAddress delivery_address { get; set; }
        public DeliveryZone delivery_zone { get; set; }
        public DeliveryService delivery_service { get; set; }
        public OrderTotal order_total { get; set; }
        public DeliveryTotal delivery_total { get; set; }
        public Enquiry enquiry { get; set; }
        public List<Item> items { get; set; }
        public List<Link> links { get; set; }
    }

    public class GetOrdersResponse
    {
        public Query query { get; set; }
        public List<NOTHSOrder> data { get; set; }
        public List<Link> links { get; set; }
    }
}
