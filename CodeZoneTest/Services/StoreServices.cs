using CodeZoneTest.Data.Models;
using CodeZoneTest.Helper;
using CodeZoneTest.Interfaces;
using CodeZoneTest.Models;
using CodeZoneTest.Models.StoreViewModels;
using LinqKit;
using Mapster;
using System.Collections.Generic;
using System.Data.Entity;

namespace CodeZoneTest.Services;

public class StoreServices:IStoreServices
{
    private readonly IRepository<Store> _storeRepository;

    public StoreServices(IRepository<Store> storeRepository)
    {
        _storeRepository = storeRepository;
    }
    public async Task<PaginationViewModel<GetStoreViewModel>> Stores(int pageIndex , int pageSize)
    {
        var storesViewModel = _storeRepository.GetAll()
                                                        .ProjectToType<GetStoreViewModel>();
        return await storesViewModel.Paginate(pageIndex, pageSize);
    }
    public IEnumerable<GetStoreViewModel> All()
    {
        var storesViewModel = _storeRepository.GetAll()
                             .ProjectToType<GetStoreViewModel>();
        return storesViewModel.ToList();
    }

    public async Task<GetStoreViewModel> GetStoreById(string id)
    {
       var store = await _storeRepository.GetByIDAsync(id);
       return store.Adapt<GetStoreViewModel>();
    }

    public async Task<GetStoreViewModel> AddStore(AddStoreViewModel model)
    {
        var newStore = model.Adapt<Store>();
        await _storeRepository.AddAsync(newStore);
        _storeRepository.Save();
        return newStore.Adapt<GetStoreViewModel>();
    }

    public void UpdateStore(GetStoreViewModel model)
    {
        var updatedStore = model.Adapt<Store>();
        _storeRepository.Update(updatedStore);
         _storeRepository.Save();
    }

    public async Task<bool> DeleteStore(string id)
    {
        var store = await _storeRepository.GetByIDAsync(id);
        if(store is not null)
        {
            _storeRepository.Delete(store);
            _storeRepository.Save();
            return true;
        }
        return false;
    }

  
}