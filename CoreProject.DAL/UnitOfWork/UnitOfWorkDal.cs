using CoreProject.DAL.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreProject.DAL.UnitOfWork
{
    public class UnitOfWorkDal : IUnitOfWorkDal
    {
        private readonly CoreProjectDbContext _dbcontext;

        public UnitOfWorkDal(CoreProjectDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbcontext.SaveChangesAsync();
        }
    }
}
