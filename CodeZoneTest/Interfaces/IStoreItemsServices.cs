using CodeZoneTest.Data.Models;
using CodeZoneTest.ViewModels.ItemViewModels;
using CodeZoneTest.ViewModels.StoreItems;

namespace CodeZoneTest.Interfaces
{
    public interface IStoreItemsServices
    {
        public AssignItemToStoreViewModel AssignItemToStoreAsync(AssignItemToStoreViewModel viewModel);
        public int GetItemsQuantity(string storeId, string itemId);
        public GetItemWithStoresViewModel GetItemWithStores(string itemId);
        public GetStoreItemQuantityViewModel GetStoreWithItems(string storeId);
    }
}
