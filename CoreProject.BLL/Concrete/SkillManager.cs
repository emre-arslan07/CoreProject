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
    public class SkillManager : ISkillService
    {
        private readonly ISkillDal _skillDal;
        private readonly IUnitOfWorkDal _unitOfWorkDal;

        public SkillManager(ISkillDal skillDal, IUnitOfWorkDal unitOfWorkDal)
        {
            _skillDal = skillDal;
            _unitOfWorkDal = unitOfWorkDal;
        }

        public async Task<bool> AddAsync(Skill model)
        {
            await _skillDal.AddAsync(model);
            if (await _unitOfWorkDal.SaveChangesAsync() >= 1)
            {
                return true;
            }
            else { return false; }
        }

        public async Task<Skill> GetByIdAsync(int id)
        {
            return await _skillDal.GetByIdAsync(id);
        }

        public async Task<Skill> GetSingleAsync(Expression<Func<Skill, bool>> method)
        {
            return await _skillDal.GetSingleAsync(method);
        }

        public IQueryable<Skill> GetWhere(Expression<Func<Skill, bool>> method)
        {
            return _skillDal.GetWhere(method);
        }

        public async Task<bool> Remove(Skill model)
        {
            _skillDal.Remove(model);
            if (await _unitOfWorkDal.SaveChangesAsync() >= 1)
            {
                return true;
            }
            else
            {
                return false;
            };
        }

        public async Task<bool> Update(Skill model)
        {
            _skillDal.Update(model);
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
