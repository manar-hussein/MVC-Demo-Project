using CodeZoneTest.Data.Models;
using CodeZoneTest.Models;
using CodeZoneTest.Models.StoreViewModels;
namespace CodeZoneTest.Interfaces;
public interface IStoreServices
{
    public Task<PaginationViewModel<GetStoreViewModel>> Stores(int pageIndex , int pageSize);
    public IEnumerable<GetStoreViewModel> All();
    public Task<GetStoreViewModel> GetStoreById(string id);
    public Task<GetStoreViewModel> AddStore(AddStoreViewModel model);
    public void UpdateStore(GetStoreViewModel model);
    public Task<bool> DeleteStore(string id);
}