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
    public class FeatureManager : IFeatureService
    {
        private readonly IFeatureDal _featureDal;
        private readonly IUnitOfWorkDal _unitOfWorkDal;

        public FeatureManager(IFeatureDal featureDal, IUnitOfWorkDal unitOfWorkDal)
        {
            _featureDal = featureDal;
            _unitOfWorkDal = unitOfWorkDal;
        }

        public async Task<bool> AddAsync(Feature model)
        {
            await _featureDal.AddAsync(model);
            if (await _unitOfWorkDal.SaveChangesAsync() >= 1)
            {
                return true;
            }
            else { return false; }
        }

        public async Task<Feature> GetByIdAsync(int id)
        {
            return await _featureDal.GetByIdAsync(id);
        }

        public async Task<Feature> GetSingleAsync(Expression<Func<Feature, bool>> method)
        {
            return await _featureDal.GetSingleAsync(method);
        }

        public IQueryable<Feature> GetWhere(Expression<Func<Feature, bool>> method)
        {
            return _featureDal.GetWhere(method);
        }

        public async Task<bool> Remove(Feature model)
        {
            _featureDal.Remove(model);
            if (await _unitOfWorkDal.SaveChangesAsync() >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> Update(Feature model)
        {
            _featureDal.Update(model);
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
