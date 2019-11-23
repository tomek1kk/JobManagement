using JobManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobManagement.Data
{
    public class GenericUoW<T> where T : class
    {
        private GenericRepository<T> repository;
        private ApplicationDbContext context;

        public GenericUoW(ApplicationDbContext context)
        {
            this.context = context;
        }

        public GenericRepository<T> Repository
        {
            get
            {
                if (repository == null)
                    repository = new GenericRepository<T>(context);
                return repository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
