using JobManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobManagement.Data
{
    public class ApplicationUoW
    {
        private GenericRepository<JobApplication> applicationsRepository;

        private ApplicationDbContext context;

        public ApplicationUoW(ApplicationDbContext context)
        {
            this.context = context;
        }

        public GenericRepository<JobApplication> ApplicationsRepository
        {
            get
            {
                if (applicationsRepository == null)
                    return new GenericRepository<JobApplication>(context);
                return applicationsRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
