using CodeZoneTest.Data.Models;
using CodeZoneTest.Interfaces;
using CodeZoneTest.ViewModels.ItemViewModels;
using CodeZoneTest.ViewModels.StoreItems;
using LinqKit;
using Mapster;
using System.Linq;

namespace CodeZoneTest.Services
{
    public class StoreItemsServices : IStoreItemsServices
    {
        private readonly IRepository<StoreItems> _storeItemsRepository;

        public StoreItemsServices(IRepository<StoreItems> storeItemsRepository)
        {
            _storeItemsRepository = storeItemsRepository;
        }
        public AssignItemToStoreViewModel AssignItemToStoreAsync(AssignItemToStoreViewModel viewModel)
        {
            var oldEntity = GetItemsStore(viewModel.StoreId, viewModel.ItemId);
            if (oldEntity is null)
            {
                if (viewModel.ItemQuantity > 0)
                {
                    var newEntity = viewModel.Adapt<StoreItems>();
                    _storeItemsRepository.Add(newEntity);
                    _storeItemsRepository.Save();
                }
                return viewModel;
            }
            oldEntity.ItemQuantity = viewModel.ItemQuantity;
            if (viewModel.ItemQuantity <= 0)
            {
                _storeItemsRepository.Delete(oldEntity);
            }
            _storeItemsRepository.Save();
            return viewModel;
        }

        private StoreItems GetItemsStore(string storeId, string itemId)
        {
            var predicate = PredicateBuilder.New<StoreItems>(true);
            predicate.And(s => s.ItemId == itemId);
            predicate.And(s => s.StoreId == storeId);
            var storeItems = _storeItemsRepository.GetAll(predicate)
                             .FirstOrDefault();
            return storeItems;
        }
        public int GetItemsQuantity(string storeId, string itemId)
        {
            var storeItems = GetItemsStore(storeId, itemId);
            return storeItems is null ? 0 : storeItems.ItemQuantity;
        }

        public GetStoreItemQuantityViewModel GetStoreWithItems(string storeId)
        {
            var predicate = PredicateBuilder.New<StoreItems>(true);
            predicate = predicate.And(s => s.StoreId == storeId);
            predicate = predicate.And(s => s.ItemQuantity >0);
            var config = new TypeAdapterConfig();
            var storeItems = _storeItemsRepository.GetAll(predicate).Select(s => new StoreItemViewModel
            {
                StoreName = s.Store.Name,
                ItemName = s.Item.Name,
                ItemQuantity = s.ItemQuantity
            });
            var stores = new GetStoreItemQuantityViewModel
            {
                StoreName = storeItems.Select(s => s.StoreName).FirstOrDefault(),
                Items = storeItems.Select(s => new ItemWithQuantity { ItemName = s.ItemName, ItemQuantity = s.ItemQuantity })
            };
            return stores;
        }
        public GetItemWithStoresViewModel GetItemWithStores(string itemId)
        {
            var predicate = PredicateBuilder.New<StoreItems>(true);
            predicate = predicate.And(s => s.ItemId == itemId);
            predicate = predicate.And(s => s.ItemQuantity > 0);
            var storesItem = _storeItemsRepository.GetAll(predicate).Select(s => new StoreItemViewModel
            {
                StoreName = s.Store.Name,
                ItemName = s.Item.Name,
                ItemQuantity = s.ItemQuantity
            });
            var stores = new GetItemWithStoresViewModel
            {
                ItemName = storesItem.Select(s => s.ItemName).FirstOrDefault(),
                Stores = storesItem.Select(s => new StoreWithQuantity { StoreName = s.StoreName, ItemQuantity = s.ItemQuantity })
            };
            return stores;
        }

    }
}
