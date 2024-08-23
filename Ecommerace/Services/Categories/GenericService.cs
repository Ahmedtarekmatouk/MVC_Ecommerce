using Ecommerace.Repositories;

namespace Ecommerace.Services.Categories
{
    public class GenericService<T> : IGenericService<T> where T : class
    {

        private readonly IRepository<T> _repository;

        public GenericService(IRepository<T> repository)
        {
            _repository = repository;
        }
        public void Create(T entity)
        {
            _repository.Create(entity);
            _repository.Save();
        }

        /// <summary>
        /// Delete take id not entity
        /// </summary>
        /// <returns></returns>
        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public List<T> GetAll()
        {
            return _repository.GetAll();
        }

        public T GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Update(T entity)
        {
            _repository.Update(entity);
        }
    }
}
