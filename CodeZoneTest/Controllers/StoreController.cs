using CodeZoneTest.Interfaces;
using CodeZoneTest.Models.StoreViewModels;
using CodeZoneTest.ViewModels.StoreViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CodeZoneTest.Controllers;

public class StoreController : Controller
{
    private readonly IStoreServices _storeService;
    private readonly IStoreItemsServices _storeItemsServices;

    public StoreController(IStoreServices storeService ,IStoreItemsServices storeItemsServices)
    {
        _storeService = storeService;
        _storeItemsServices = storeItemsServices;
    }
    public async Task<IActionResult> Index(int pageIndex , int pageSize)
    {
        var stores =await _storeService.Stores(pageIndex , pageSize);
        var model = new IndexStoreViewModel
        {
            AllStoresModel = stores,
        };
        return View(model);
    }
    [HttpGet]
    public IActionResult Create()
    {
        return PartialView("Create");
    }

    [HttpPost]
    public async Task<IActionResult> Create(AddStoreViewModel viewModel)
    {
        if(!ModelState.IsValid)
        {
            return View(viewModel);
        }
        await _storeService.AddStore(viewModel);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Details(string id)
    {
        var Item = _storeItemsServices.GetStoreWithItems(id);
        return View(Item);
    }

    [HttpPost]
    public IActionResult Update(GetStoreViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            return View(viewModel);
        }
        _storeService.UpdateStore(viewModel);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Update(string Id)
    {
        var oldStore =await _storeService.GetStoreById(Id);
        return PartialView(oldStore);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(string id)
    {
        var store =await  _storeService.GetStoreById(id);
        return PartialView(store);
    }

    [HttpPost]
    public async Task<IActionResult>Delete(string id ,bool confirmDelete = true)
    {
        var store = await _storeService.DeleteStore(id);
        return RedirectToAction(nameof(Index));
    }



}