namespace OrderSummaryApp
{
    public class OrderSummary
    {
        public string ClientNumber { get; set; }
        public string ShippingAddress { get; set; }
        public string DeliveryAddress { get; set; }
        public int PackingType { get; set; }
        public string TransportType { get; set; }
    }
}
