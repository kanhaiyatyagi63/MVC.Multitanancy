using Microsoft.AspNetCore.Mvc;
using MVC.Core.Interfaces;
using MVC.Multitanancy.Models.Product;

namespace MVC.Multitanancy.Controllers;
public class ProductController : Controller
{
    private readonly IProductService _service;
    public ProductController(IProductService service)
    {
        _service = service;
    }
    public async Task<IActionResult> Index()
    {
        return View(await _service.GetAllAsync());
    }
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateProductModel request)
    {
        if (!ModelState.IsValid)
            return View(request);
        await _service.CreateAsync(request.Name, request.Description, request.Rate);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> View(int id)
    {
        if (id <= 0)
            return NotFound();
        var productDetails = await _service.GetByIdAsync(id);
        return Ok(productDetails);
    }
}