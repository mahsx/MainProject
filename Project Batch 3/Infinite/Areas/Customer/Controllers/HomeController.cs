using Microsoft.AspNetCore.Mvc;
using batch3.Models;
using batch3.Repositories;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using batch3.Utils;

namespace batch3.Controllers;

[Area("Customer")]
public class HomeController : Controller
{
    private readonly IProductRepository _productRepository;
    private readonly IShoppingCartRepository _shoppingCartRepository;
    private readonly ICategoryRepository _categoryRepository;


    public HomeController(IProductRepository productRepository, IShoppingCartRepository shoppingCartRepository, ICategoryRepository categoryRepository)
    {
        _productRepository = productRepository;
        _shoppingCartRepository = shoppingCartRepository;
        _categoryRepository = categoryRepository;
    }
    public IActionResult Index(string categoryId, string productTitle)
    {
        IEnumerable<Product> products = _productRepository.GetAll(includeProperties: "Category");

        if (!string.IsNullOrEmpty(categoryId))
        {
            // Filter products by categoryId
            int parsedCategoryId;
            if (int.TryParse(categoryId, out parsedCategoryId))
            {
                products = products.Where(p => p.CategoryId == parsedCategoryId);
            }
        }

        if (!string.IsNullOrEmpty(productTitle))
        {
            // Filter products by productTitle
            products = products.Where(p => p.Title.ToLower().Contains(productTitle.ToLower()));
        }

        ViewBag.CategoryId = categoryId; // Pass categoryId to the view
        ViewBag.ProductTitle = productTitle; // Pass productTitle to the view

        ViewBag.Categories = _categoryRepository.GetAll();  // Assuming GetAll() returns List<Category>

        return View(products);
    }




    public IActionResult Details(int id)
    {
        ShoppingCart cart = new ShoppingCart();
        Product? product = _productRepository.Get(i => i.ProductId == id, includeProperties: "Category");
        if (product == null)
        {
            return NotFound();
        }
        cart.Product = product;
        cart.ProductId = product.ProductId;
        cart.Quantity = 1;
        return View(cart);
    }

    [HttpPost]
    [Authorize]
    public IActionResult Details(ShoppingCart cart)
    {
        var claimsIdentity = (ClaimsIdentity)User.Identity;
        var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

        ShoppingCart? cartFromDb = _shoppingCartRepository.Get(
            i => i.ProductId == cart.ProductId && i.UserId == userId);
        cart.UserId = userId;
        if (cartFromDb == null)
        {
            _shoppingCartRepository.Insert(cart);
            _shoppingCartRepository.Save();
            HttpContext.Session.SetInt32(SD.SessionCart, _shoppingCartRepository.GetAll(i => i.UserId == userId).Count());
        }
        else
        {
            cartFromDb.Quantity += cart.Quantity;
            _shoppingCartRepository.Update(cartFromDb);
            _shoppingCartRepository.Save();
        }
        TempData["Message"] = "Item added to cart successfully";

        return RedirectToAction("Index");
    }

    public IActionResult Privacy()
    {
        return View();
    }

}
