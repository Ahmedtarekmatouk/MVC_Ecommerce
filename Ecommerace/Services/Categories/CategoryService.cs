using System.Collections.Generic;
using Ecommerace.Models;
using Ecommerace.Repositories;
using Ecommerace.Repositories.Categories;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Ecommerace.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryService(ICategoryRepository _categoryRepository)
        {
            this.categoryRepository = _categoryRepository;
        }

        public List<Category> GetAllCategories()
        {
            var categories = categoryRepository.GetAll();
            return categories ?? new List<Category>();
        }

        public void CreateCategory(Category category)
        {

            categoryRepository.Create(category);

        }

        public void UpdateCategory(Category category)
        {
            categoryRepository.Update(category);
        }

        public void DeleteCategory(int id)
        {
            categoryRepository.Delete(id);
        }

        public Category GetCategoryById(int id)
        {
            return categoryRepository.GetById(id);
        }

        public void saveChanges()
        {
            categoryRepository.Save();
        }
    }
}
