using CodeZoneTest.Data.Models;
using CodeZoneTest.Helper;
using CodeZoneTest.Interfaces;
using CodeZoneTest.Models;
using CodeZoneTest.Models.ItemViewModels;
using CodeZoneTest.ViewModels.ItemViewModels;
using Mapster;
using System.Collections.Generic;
using System.Data.Entity;

namespace CodeZoneTest.Services;

public class ItemServices:IItemServices
{
    private readonly IRepository<Item> _itemRepository;

    public ItemServices(IRepository<Item> itemRepository)
    {
        _itemRepository = itemRepository;
    }
    public async Task<PaginationViewModel<GetItemViewModel>> Items(int pageIndex , int pageSize)
    {
        var itemsViewModel = _itemRepository.GetAll()
                              .ProjectToType<GetItemViewModel>();
        return await itemsViewModel.Paginate(pageIndex, pageSize);
    }
    public IEnumerable<GetItemViewModel> All()
    {
        var itemsViewModel = _itemRepository.GetAll()
                              .ProjectToType<GetItemViewModel>();
        return itemsViewModel.ToList();
    }

    public async Task<GetItemViewModel> GetItemById(string id)
    {
       var Item = await _itemRepository.GetByIDAsync(id);
       return Item.Adapt<GetItemViewModel>();
    }

    public async Task<GetItemViewModel> AddItem(AddItemViewModel model)
    {
        var newItem = model.Adapt<Item>();
        await _itemRepository.AddAsync(newItem);
         _itemRepository.Save();
        return newItem.Adapt<GetItemViewModel>();
    }

    public void UpdateItem(GetItemViewModel model)
    {
        var updatedItem = model.Adapt<Item>();
        _itemRepository.Update(updatedItem);
         _itemRepository.Save();
    }

    public async Task<bool> DeleteItem(string id)
    {
        var Item = await _itemRepository.GetByIDAsync(id);
        if(Item is not null)
        {
            _itemRepository.Delete(Item);
             _itemRepository.Save();
            return true;
        }
        return false;
    }
}