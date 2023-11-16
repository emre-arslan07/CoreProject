using CoreProject.BLL.Abstract;
using CoreProject.DAL.Abstract;
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
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal _aboutDal;
        private readonly IUnitOfWorkDal _unitOfWorkDal;

        public AboutManager(IAboutDal aboutDal, IUnitOfWorkDal unitOfWorkDal)
        {
            _aboutDal = aboutDal;
            _unitOfWorkDal = unitOfWorkDal;
        }

        public async Task<bool> AddAsync(About model)
        {
            await _aboutDal.AddAsync(model);
            if (await _unitOfWorkDal.SaveChangesAsync() >= 1)
            {
                return true;
            }
            else { return false; }
        }

        public async Task<About> GetByIdAsync(int id)
        {
            return await _aboutDal.GetByIdAsync(id);
        }

        public async Task<About> GetSingleAsync(Expression<Func<About, bool>> method)
        {
            return await _aboutDal.GetSingleAsync(method);
        }

        public IQueryable<About> GetWhere(Expression<Func<About, bool>> method)
        {
            return _aboutDal.GetWhere(method);
        }

        public async Task<bool> Remove(About model)
        {
            _aboutDal.Remove(model);
            if (await _unitOfWorkDal.SaveChangesAsync() >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> Update(About model)
        {
            _aboutDal.Update(model);
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
