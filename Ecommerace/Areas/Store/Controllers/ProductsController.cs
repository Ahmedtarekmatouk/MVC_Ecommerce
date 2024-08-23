using Ecommerace.Models;
using Ecommerace.Services.Categories;
using Ecommerace.Services;
using Ecommerace.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace Ecommerace.Areas.Store.Controllers
{
    [Area("Store")]
    public class ProductsController : Controller
    {
        private readonly IProductsService productsService;
        private readonly ICategoryService categoryService;
        private readonly UserManager<ApplicationUser> userManager;

        public ProductsController(IProductsService productsService,
            ICategoryService categoryService, UserManager<ApplicationUser> userManager)
        {
            this.productsService = productsService;
            this.categoryService = categoryService;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            var products = productsService.GetAll();
            return View("Index", products);
        }

        public IActionResult Details(int id)
        {
            var productDetails = productsService.GetById(id);
            return View(productDetails);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var categories = categoryService.GetAllCategories().ToList();
            var viewModel = new ProductsWithCategoryList
            {
                Categories = categories.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductsWithCategoryList viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.GetUserAsync(User);
                var storeId = User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier)?.Value;

                var product = new Products
                {
                    Name = viewModel.Name,
                    Slug = $"{viewModel.Name}_{Guid.NewGuid()}",
                    Description = viewModel.Description,
                    CategoryId = (int)viewModel.CategoryId,
                    StoreId = storeId,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };
                productsService.Create(product);
                return RedirectToAction("Index");
            }

            viewModel.Categories = categoryService.GetAllCategories().Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = productsService.GetById(id);
            var categories = categoryService.GetAllCategories().ToList();
            var viewModel = new ProductsWithCategoryList
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                CategoryId = product.CategoryId,
                CreatedAt = product.CreatedAt,
                UpdatedAt = product.UpdatedAt,
                Categories = categories.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductsWithCategoryList viewModel)
        {
            if (ModelState.IsValid)
            {
                var product = productsService.GetById(viewModel.Id);
                var storeId = User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier)?.Value;

                product.Name = viewModel.Name;
                product.Slug = $"{viewModel.Name}_{Guid.NewGuid()}";
                product.Description = viewModel.Description;
                product.CategoryId = (int)viewModel.CategoryId;
                product.StoreId = storeId;
                product.UpdatedAt = DateTime.UtcNow;

                productsService.Update(product);
                return RedirectToAction("Index");
            }

            viewModel.Categories = categoryService.GetAllCategories().Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();

            return View(viewModel);
        }

        public IActionResult Delete(int id)
        {
            productsService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public JsonResult GetSubCategories(int categoryId)
        {
            var subCategories = categoryService.GetAllCategories().Where(c => c.Parent_Id == categoryId).ToList();
            var subCategoryList = subCategories.Select(sc => new SelectListItem
            {
                Value = sc.Id.ToString(),
                Text = sc.Name
            }).ToList();
            return Json(subCategoryList);
        }
    }
}