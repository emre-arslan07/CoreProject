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
    public class AnnouncementManager : IAnnouncementService
    {
        private readonly IUnitOfWorkDal _unitOfWorkDal;
        private readonly IAnnouncementDal _announcementDal;

        public AnnouncementManager(IUnitOfWorkDal unitOfWorkDal, IAnnouncementDal announcementDal)
        {
            _unitOfWorkDal = unitOfWorkDal;
            _announcementDal = announcementDal;
        }

        public async Task<bool> AddAsync(Announcement model)
        {
            await _announcementDal.AddAsync(model);
            if (await _unitOfWorkDal.SaveChangesAsync() >= 1)
            {
                return true;
            }
            else { return false; }
        }

        public async Task<Announcement> GetByIdAsync(int id)
        {
            return await _announcementDal.GetByIdAsync(id);
        }

        public async Task<Announcement> GetSingleAsync(Expression<Func<Announcement, bool>> method)
        {
            return await _announcementDal.GetSingleAsync(method);
        }

        public IQueryable<Announcement> GetWhere(Expression<Func<Announcement, bool>> method)
        {
            return _announcementDal.GetWhere(method);
        }

        public async Task<bool> Remove(Announcement model)
        {
            _announcementDal.Remove(model);
            if (await _unitOfWorkDal.SaveChangesAsync() >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> Update(Announcement model)
        {
            _announcementDal.Update(model);
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
