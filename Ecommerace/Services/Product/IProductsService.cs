using Ecommerace.Models;
using Ecommerace.Repositories;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Ecommerace.Services
{
    public interface IProductsService : IService
    {
        List<Products> GetAll();
        Products GetById(int id);
        void Create(Products entity);
        void Update(Products entity);
        void Delete(int id);
        void Save();



    }
}