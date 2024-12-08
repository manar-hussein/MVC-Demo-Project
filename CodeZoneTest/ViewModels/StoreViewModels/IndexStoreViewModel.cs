using CodeZoneTest.Models;
using CodeZoneTest.Models.StoreViewModels;

namespace CodeZoneTest.ViewModels.StoreViewModels
{
    public class IndexStoreViewModel
    {
        public PaginationViewModel<GetStoreViewModel> AllStoresModel { get; set; }
        public AddStoreViewModel CreateViewModel { get; set; }
        public GetStoreViewModel UpdateViewModel { get; set; }
    }
}
