namespace CodeZoneTest.ViewModels.ItemViewModels
{
    public class GetItemWithStoresViewModel
    {
        public string ItemName { get; set; }
        public IEnumerable<StoreWithQuantity> Stores { get; set; }
    }

    public class StoreWithQuantity
    {
        public string StoreName { get; set; }
        public int ItemQuantity { get; set; }
    }
}
