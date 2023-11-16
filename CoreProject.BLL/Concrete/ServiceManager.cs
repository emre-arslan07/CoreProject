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
    public class ServiceManager : IServiceService
    {
        private readonly IServiceDal _serviceDal;
        private readonly IUnitOfWorkDal _unitOfWorkDal;

        public ServiceManager(IServiceDal serviceDal, IUnitOfWorkDal unitOfWorkDal)
        {
            _serviceDal = serviceDal;
            _unitOfWorkDal = unitOfWorkDal;
        }

        public async Task<bool> AddAsync(Service model)
        {
            await _serviceDal.AddAsync(model);
            if (await _unitOfWorkDal.SaveChangesAsync() >= 1)
            {
                return true;
            }
            else { return false; }
        }

        public async Task<Service> GetByIdAsync(int id)
        {
            return await _serviceDal.GetByIdAsync(id);
        }

        public async Task<Service> GetSingleAsync(Expression<Func<Service, bool>> method)
        {
            return await _serviceDal.GetSingleAsync(method);
        }

        public IQueryable<Service> GetWhere(Expression<Func<Service, bool>> method)
        {
            return _serviceDal.GetWhere(method);
        }

        public async Task<bool> Remove(Service model)
        {
            _serviceDal.Remove(model);
            if (await _unitOfWorkDal.SaveChangesAsync() >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> Update(Service model)
        {

            _serviceDal.Update(model);
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
