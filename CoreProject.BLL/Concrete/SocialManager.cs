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
    public class SocialManager : ISocialMediaService
    {
        private readonly ISocialMediaDal _socialMediaDal;
        private readonly IUnitOfWorkDal _unitOfWorkDal;

        public SocialManager(ISocialMediaDal socialMediaDal, IUnitOfWorkDal unitOfWorkDal)
        {
            _socialMediaDal = socialMediaDal;
            _unitOfWorkDal = unitOfWorkDal;
        }

        public async Task<bool> AddAsync(SocialMedia model)
        {
            await _socialMediaDal.AddAsync(model);
            if (await _unitOfWorkDal.SaveChangesAsync() >= 1)
            {
                return true;
            }
            else { return false; }
        }

        public async Task<SocialMedia> GetByIdAsync(int id)
        {
            return await _socialMediaDal.GetByIdAsync(id);
        }

        public async Task<SocialMedia> GetSingleAsync(Expression<Func<SocialMedia, bool>> method)
        {
            return await _socialMediaDal.GetSingleAsync(method);
        }

        public IQueryable<SocialMedia> GetWhere(Expression<Func<SocialMedia, bool>> method)
        {
            return _socialMediaDal.GetWhere(method);
        }

        public async Task<bool> Remove(SocialMedia model)
        {
            _socialMediaDal.Remove(model);
            if (await _unitOfWorkDal.SaveChangesAsync() >= 1)
            {
                return true;
            }
            else
            {
                return false;
            };
        }

        public async Task<bool> Update(SocialMedia model)
        {
            _socialMediaDal.Update(model);
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
