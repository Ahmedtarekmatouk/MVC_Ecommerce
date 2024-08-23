using Ecommerace.Helpers;
using Ecommerace.Models;
using Ecommerace.Services;
using Ecommerace.Services.Categories;
using Ecommerace.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Ecommerace.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private MVCECommeraceContext _context;
        IWebHostEnvironment _webHostEnvironment;

        public CategoryController(ICategoryService categoryService , MVCECommeraceContext context, IWebHostEnvironment webHostEnvironment)
        {
            _categoryService = categoryService;
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index(int page = 1,  int pageSize = 10,string search = "")
        {
            var categories = _context.Categories.Include("Parent").Skip((page - 1) * pageSize).Take(pageSize).Where(x => x.Name.ToLower().Contains(search.ToLower())).ToList();
            ViewBag.Pager = PaginatorHelper.setPagination(_context.Categories.Where(x => x.Name.ToLower().Contains(search.ToLower())).Count(), page, pageSize);
            ViewBag.controller = "Category";
            return View("Index", categories);
        }

        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_context.Categories.Where(c => c.Parent_Id == null).ToList(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateCategoryViewModel category)
        {
            if (ModelState.IsValid)
            {
                Category newCategory = new Category { Name = category.Name, Parent_Id = category.ParentId };
                if(category.Image != null)
                {
                    string file_name = ImageUploaderHelper.upload(category.Image , _webHostEnvironment);
                    newCategory.Image = file_name;
                }
                _categoryService.CreateCategory(newCategory);
                _categoryService.saveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Categories = new SelectList(_categoryService.GetAllCategories(), "Id", "Name");
            return View(category);
        }

        public IActionResult Edit(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }

            ViewBag.Categories = new SelectList(_categoryService.GetAllCategories(), "Id", "Name", category.Parent_Id);
            return View(category);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryService.UpdateCategory(category);
                _categoryService.saveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Categories = new SelectList(_categoryService.GetAllCategories(), "Id", "Name", category.Parent_Id);
            return View(category);
        }

        public IActionResult Delete(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }

            _categoryService.DeleteCategory(id);
            _categoryService.saveChanges();
            return RedirectToAction("Index");
        }

    }
}
