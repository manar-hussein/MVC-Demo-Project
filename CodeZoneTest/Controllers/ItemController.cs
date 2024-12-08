using CodeZoneTest.Data.Models;
using CodeZoneTest.Interfaces;
using CodeZoneTest.Models.ItemViewModels;
using CodeZoneTest.Services;
using CodeZoneTest.ViewModels.ItemViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CodeZoneTest.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemServices _itemService;
        private readonly IStoreItemsServices _storeItemsServices;

        public ItemController(IItemServices itemService , IStoreItemsServices storeItemsServices)
        {
            _itemService = itemService;
            _storeItemsServices = storeItemsServices;
        }
        public async Task<IActionResult> Index(int pageIndex, int pageSize)
        {
            var Items = await _itemService .Items(pageIndex, pageSize);
            var model = new IndexItemViewModel
            {
                AllItemsModel = Items,
            };
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return PartialView("Create");
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddItemViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            await _itemService.AddItem(viewModel);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Details(string id)
        {
            var Item = _storeItemsServices.GetItemWithStores(id);
            return View(Item);
        }

        [HttpPost]
        public IActionResult Update(GetItemViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
             _itemService.UpdateItem(viewModel);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(string Id)
        {
            var oldItem = await _itemService.GetItemById(Id);
            return PartialView(oldItem);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var Item = await _itemService.GetItemById(id);
            return PartialView(Item);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id, bool confirmDelete = true)
        {
            var Item = await _itemService.DeleteItem(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
