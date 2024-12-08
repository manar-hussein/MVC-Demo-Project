using CodeZoneTest.Interfaces;
using CodeZoneTest.ViewModels.StoreItems;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace CodeZoneTest.Controllers
{
    public class StoreItemsController : Controller
    {
        private readonly IStoreItemsServices _storeItemsServices;
        private readonly IStoreServices _storeServices;
        private readonly IItemServices _itemServices;

        public StoreItemsController(IStoreItemsServices storeItemsServices , IStoreServices storeServices ,IItemServices itemServices)
        {
            _storeItemsServices = storeItemsServices;
            _storeServices = storeServices;
            _itemServices = itemServices;
        }
        public IActionResult Index(AssignItemToStoreViewModel viewModel)
        {
            var stores =  _storeServices.All();
            var items =  _itemServices.All();
            var model = new IndexItemsStoresViewModel
            {
                AllStore = stores,
                AllItems = items,
            };
            if(viewModel.StoreId.IsNullOrEmpty())
            {
                model.StoreId = viewModel.StoreId;
                model.ItemId = viewModel.ItemId;
                model.ItemQuantity = viewModel.ItemQuantity;
            }
            return View(model);
        }

        public int GetQuantity(string storeId , string itemId)
        {
            var itemQuantity = _storeItemsServices.GetItemsQuantity(storeId, itemId);
            return  itemQuantity ;
        }

        [HttpPost]
        public IActionResult Add(AssignItemToStoreViewModel model )
        {
            if(!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index), model);
            }
            var result =  _storeItemsServices.AssignItemToStoreAsync(model);
            return RedirectToAction(nameof(Details), "Store", routeValues: new { id = result.StoreId});
        }
    }
}
