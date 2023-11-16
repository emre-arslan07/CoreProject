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
    public class MessageManager : IMessageService
    {
        private readonly IMessageDal _messageDal;
        private readonly IUnitOfWorkDal _unitOfWorkDal;

        public MessageManager(IMessageDal messageDal, IUnitOfWorkDal unitOfWorkDal)
        {
            _messageDal = messageDal;
            _unitOfWorkDal = unitOfWorkDal;
        }

        public async Task<bool> AddAsync(Message model)
        {
            await _messageDal.AddAsync(model);
            if (await _unitOfWorkDal.SaveChangesAsync() >= 1)
            {
                return true;
            }
            else { return false; }
        }

        public async Task<Message> GetByIdAsync(int id)
        {
            return await _messageDal.GetByIdAsync(id);
        }

        public async Task<Message> GetSingleAsync(Expression<Func<Message, bool>> method)
        {
            return await _messageDal.GetSingleAsync(method);
        }

        public IQueryable<Message> GetWhere(Expression<Func<Message, bool>> method)
        {
            return _messageDal.GetWhere(method);
        }

        public async Task<bool> Remove(Message model)
        {
            _messageDal.Remove(model);
            if (await _unitOfWorkDal.SaveChangesAsync() >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> Update(Message model)
        {
            _messageDal.Update(model);
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
