using CoreProject.BLL.Abstract;
using CoreProject.DAL.Abstract;
using CoreProject.DAL.EntityFramework;
using CoreProject.DAL.UnitOfWork;
using CoreProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoreProject.BLL.Concrete
{
    public class AppUserManager : IAppUserService
    {
        private readonly IUnitOfWorkDal _unitOfWorkDal;
        private readonly IAppUserDal _appUserDal;

        public AppUserManager(IUnitOfWorkDal unitOfWorkDal, IAppUserDal appUserDal)
        {
            _unitOfWorkDal = unitOfWorkDal;
            _appUserDal = appUserDal;
        }

        public async Task<bool> AddAsync(AppUser model)
        {
            await _appUserDal.AddAsync(model);
            if (await _unitOfWorkDal.SaveChangesAsync() >= 1)
            {
                return true;
            }
            else { return false; }
        }

        public async Task<AppUser> GetByIdAsync(int id)
        {
            return await _appUserDal.GetByIdAsync(id);
        }

        public Task<AppUser> GetSingleAsync(Expression<Func<AppUser, bool>> method)
        {
            throw new NotImplementedException();
        }

        public IQueryable<AppUser> GetWhere(Expression<Func<AppUser, bool>> method)
        {
            return _appUserDal.GetWhere(method);
        }

        public Task<bool> Remove(AppUser model)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(AppUser model)
        {
            _appUserDal.Update(model);
            if (await _unitOfWorkDal.SaveChangesAsync() >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
