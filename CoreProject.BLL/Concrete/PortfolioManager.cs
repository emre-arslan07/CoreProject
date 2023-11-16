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
    public class PortfolioManager : IPortfolioService
    {
        private readonly IPortfolioDal _portfolioDal;
        private readonly IUnitOfWorkDal _unitOfWorkDal;

        public PortfolioManager(IPortfolioDal portfolioDal, IUnitOfWorkDal unitOfWorkDal)
        {
            _portfolioDal = portfolioDal;
            _unitOfWorkDal = unitOfWorkDal;
        }

        public async Task<bool> AddAsync(Portfolio model)
        {
            await _portfolioDal.AddAsync(model);
            if (await _unitOfWorkDal.SaveChangesAsync() >= 1)
            {
                return true;
            }
            else { return false; }
        }

        public async Task<Portfolio> GetByIdAsync(int id)
        {
            return await _portfolioDal.GetByIdAsync(id);
        }

        public async Task<Portfolio> GetSingleAsync(Expression<Func<Portfolio, bool>> method)
        {
            return await _portfolioDal.GetSingleAsync(method);
        }

        public IQueryable<Portfolio> GetWhere(Expression<Func<Portfolio, bool>> method)
        {
            return _portfolioDal.GetWhere(method);
        }

        public async Task<bool> Remove(Portfolio model)
        {
            _portfolioDal.Remove(model);
            if (await _unitOfWorkDal.SaveChangesAsync() >= 1)
            {
                return true;
            }
            else
            {
                return false;
            };
        }

        public async Task<bool> Update(Portfolio model)
        {
            _portfolioDal.Update(model);
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
