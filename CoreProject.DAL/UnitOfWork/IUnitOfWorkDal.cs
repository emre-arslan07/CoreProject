using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreProject.DAL.UnitOfWork
{
    public interface IUnitOfWorkDal
    {
        Task<int>  SaveChangesAsync();
    }
}
