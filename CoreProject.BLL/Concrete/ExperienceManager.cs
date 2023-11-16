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
    public class ExperienceManager : IExperienceService
    {
        private readonly IExperinceDal _experinceDal;
        private readonly IUnitOfWorkDal _unitOfWorkDal;

        public ExperienceManager(IExperinceDal experinceDal, IUnitOfWorkDal unitOfWorkDal)
        {
            _experinceDal = experinceDal;
            _unitOfWorkDal = unitOfWorkDal;
        }

        public async Task<bool> AddAsync(Experience model)
        {
            await _experinceDal.AddAsync(model);
            if (await _unitOfWorkDal.SaveChangesAsync() >= 1)
            {
                return true;
            }
            else { return false; }
        }

        public async Task<Experience> GetByIdAsync(int id)
        {
            return await _experinceDal.GetByIdAsync(id);
        }

        public async Task<Experience> GetSingleAsync(Expression<Func<Experience, bool>> method)
        {
            return await _experinceDal.GetSingleAsync(method);
        }

        public IQueryable<Experience> GetWhere(Expression<Func<Experience, bool>> method)
        {
            return _experinceDal.GetWhere(method);
        }

        public async Task<bool> Remove(Experience model)
        {
            _experinceDal.Remove(model);
            if (await _unitOfWorkDal.SaveChangesAsync() >= 1)
            {
                return true;
            }
            else
            {
                return false;
            };
        }

        public async Task<bool> Update(Experience model)
        {
            _experinceDal.Update(model);
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
