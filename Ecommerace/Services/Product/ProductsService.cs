using Ecommerace.Models;
using Ecommerace.Repositories;
using Ecommerace.Repositories.Product;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Ecommerace.Services.Product
{
    public class ProductsService : IProductsService
    {
        IProductsRepository _productsRepository;
        public ProductsService(IProductsRepository productsRepository)
        {
            this._productsRepository = productsRepository;
        }

        public void Create(Products entity)
        {
            _productsRepository.Create(entity);
            _productsRepository.Save();

        }

        public void Delete(int id)
        {
            _productsRepository.Delete(id);
            _productsRepository.Save();
        }

        public List<Products> GetAll()
        {
            return _productsRepository.GetAll();
        }

        public Products GetById(int id)
        {
            return _productsRepository.GetById(id);
        }

        public void Save()
        {
            _productsRepository.Save();
        }

        public void Update(Products entity)
        {
            _productsRepository.Update(entity);
            _productsRepository.Save();
        }
    }
}