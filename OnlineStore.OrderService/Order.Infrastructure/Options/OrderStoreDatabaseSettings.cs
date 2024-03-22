namespace Order.Infrastructure.Options
{
    public class OrderStoreDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string OrderCollectionName { get; set; }
        public string OrderDetailsCollectionName { get; set; }
        public string OrderProductsCollectionName { get; set; }
    }
}