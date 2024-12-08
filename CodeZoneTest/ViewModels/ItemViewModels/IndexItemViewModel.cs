using CodeZoneTest.Models.StoreViewModels;
using CodeZoneTest.Models;
using CodeZoneTest.Models.ItemViewModels;

namespace CodeZoneTest.ViewModels.ItemViewModels
{
    public class IndexItemViewModel
    {
        public PaginationViewModel<GetItemViewModel> AllItemsModel { get; set; }
        public AddItemViewModel CreateViewModel { get; set; }
        public GetItemViewModel UpdateViewModel { get; set; }
    }
}
