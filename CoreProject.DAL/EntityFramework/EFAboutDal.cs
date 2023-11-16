using CoreProject.DAL.Abstract;
using CoreProject.DAL.Concrete;
using CoreProject.DAL.Repositories;
using CoreProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreProject.DAL.EntityFramework
{
    public class EFAboutDal : GenericRepository<About>, IAboutDal
    {
        public EFAboutDal(CoreProjectDbContext dbContext) : base(dbContext)
        {
        }
    }
}
