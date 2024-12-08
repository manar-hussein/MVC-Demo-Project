using CodeZoneTest.Models.ItemViewModels;
using CodeZoneTest.Models.StoreViewModels;

namespace CodeZoneTest.ViewModels.StoreItems
{
    public class IndexItemsStoresViewModel
    {
        public IEnumerable<GetStoreViewModel> AllStore { get; set; }
        public IEnumerable<GetItemViewModel> AllItems { get; set; }
        public string StoreId { get; set; }
        public string ItemId { get; set; }
        public int ItemQuantity { get; set; }
    }
}
