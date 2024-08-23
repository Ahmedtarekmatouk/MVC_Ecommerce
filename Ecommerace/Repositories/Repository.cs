<<<<<<< HEAD
﻿
=======
﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
>>>>>>> 9a16458b83e00249dcf5c2e263206d75fa2acb97
using Ecommerace.Models;

namespace Ecommerace.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
<<<<<<< HEAD
    {
        MVCECommeraceContext Context;
        public Repository(MVCECommeraceContext _Context) {
            Context = _Context;
        }
        public void Create(T entity)
        {
            Context.Add(entity);
            Console.WriteLine(Context.Entry(entity).State); // This should output "Added"
        }

        public void Delete(int id)
        {
            T entity = GetById(id);
            Context.Remove(entity);
=======
    { 
        private readonly MVCECommeraceContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(MVCECommeraceContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
>>>>>>> 9a16458b83e00249dcf5c2e263206d75fa2acb97
        }

        public List<T> GetAll()
        {
<<<<<<< HEAD
            return Context.Set<T>().ToList();
=======
            return _dbSet.ToList() ?? new List<T>();
>>>>>>> 9a16458b83e00249dcf5c2e263206d75fa2acb97
        }

        public T GetById(int id)
        {
<<<<<<< HEAD
            return Context.Set<T>().Find(id);
        }

        public void Save()
        {
            Context.SaveChanges();
=======
            return _dbSet.Find(id);
        }

        public void Create(T entity)
        {
            _dbSet.Add(entity);
            Save();
>>>>>>> 9a16458b83e00249dcf5c2e263206d75fa2acb97
        }

        public void Update(T entity)
        {
<<<<<<< HEAD
            Context.Update(entity);
=======
            var entry = _context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            entry.State = EntityState.Modified;
            Save();
        }

        public void Delete(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
>>>>>>> 9a16458b83e00249dcf5c2e263206d75fa2acb97
        }
    }
}
