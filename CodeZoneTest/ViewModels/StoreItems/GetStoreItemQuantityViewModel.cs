namespace CodeZoneTest.ViewModels.StoreItems
{
    public class GetStoreItemQuantityViewModel
    {
        public string StoreName { get; set; }
        public IEnumerable<ItemWithQuantity> Items { get; set; }
    }

    public class ItemWithQuantity
    {
        public string ItemName { get; set; }
        public int ItemQuantity { get; set; }
    }
}
