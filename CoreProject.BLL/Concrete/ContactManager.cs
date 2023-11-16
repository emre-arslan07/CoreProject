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
    public class ContactManager : IContactService
    {
        private readonly IContactDal _contactDal;
        private readonly IUnitOfWorkDal _unitOfWorkDal;

        public ContactManager(IContactDal contactDal, IUnitOfWorkDal unitOfWorkDal)
        {
            _contactDal = contactDal;
            _unitOfWorkDal = unitOfWorkDal;
        }

        public async Task<bool> AddAsync(Contact model)
        {
            await _contactDal.AddAsync(model);
            if (await _unitOfWorkDal.SaveChangesAsync() >= 1)
            {
                return true;
            }
            else { return false; }
        }

        public async Task<Contact> GetByIdAsync(int id)
        {
            return await _contactDal.GetByIdAsync(id);
        }

        public async Task<Contact> GetSingleAsync(Expression<Func<Contact, bool>> method)
        {
            return await _contactDal.GetSingleAsync(method);
        }

        public IQueryable<Contact> GetWhere(Expression<Func<Contact, bool>> method)
        {
            return _contactDal.GetWhere(method);
        }

        public async Task<bool> Remove(Contact model)
        {
            _contactDal.Remove(model);
            if (await _unitOfWorkDal.SaveChangesAsync() >= 1)
            {
                return true;
            }
            else
            {
                return false;
            };
        }

        public async Task<bool> Update(Contact model)
        {
            _contactDal.Update(model);
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
