using CodeZoneTest.Models.StoreViewModels;
using CodeZoneTest.Models;
using CodeZoneTest.Models.ItemViewModels;
using CodeZoneTest.ViewModels.ItemViewModels;

namespace CodeZoneTest.Interfaces
{
    public interface IItemServices
    {
        public Task<PaginationViewModel<GetItemViewModel>> Items(int pageIndex, int pageSize);
        public IEnumerable<GetItemViewModel> All();
        public Task<GetItemViewModel> GetItemById(string id);
        public Task<GetItemViewModel> AddItem(AddItemViewModel model);
        public void UpdateItem(GetItemViewModel model);
        public Task<bool> DeleteItem(string id);
    }
}
