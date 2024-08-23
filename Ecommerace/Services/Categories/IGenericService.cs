using Ecommerace.Repositories;

namespace Ecommerace.Services.Categories;

public interface IGenericService<T> : IService
{
    void Create(T entity);
    void Update(T entity);

    /// <summary>
    /// change parameters delete take integer id not entity from class
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    // void Delete(T entity);
    T GetById(int id);
    List<T> GetAll();

}
