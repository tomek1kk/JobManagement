using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace JobManagement.Data
{
    public class GenericRepository<T> where T : class
    {
        private ApplicationDbContext context;
        private DbSet<T> dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }

        public List<T> GetAll()
        {
            return dbSet.ToList<T>();
        }

        public void AddItem(T item)
        {
            dbSet.Add(item);
        }

        public void DeleteItem(T item)
        {
            dbSet.Remove(item);
        }

        public void UpdateItem(T item)
        {
            dbSet.Update(item);
        }

        public T GetItem(int id)
        {
            var item = dbSet.Find(id);
            if (item == null)
                throw new Exception("item not found");
            return item;
        }


    }
}
