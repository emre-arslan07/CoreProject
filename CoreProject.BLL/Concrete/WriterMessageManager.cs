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
    public class WriterMessageManager : IWriterMessageService
    {
        private readonly IWriterMessageDal _writerMessageDal;
        private readonly IUnitOfWorkDal _unitOfWorkDal;

        public WriterMessageManager(IWriterMessageDal writerMessageDal, IUnitOfWorkDal unitOfWorkDal)
        {
            _writerMessageDal = writerMessageDal;
            _unitOfWorkDal = unitOfWorkDal;
        }

        public async Task<bool> AddAsync(WriterMessage model)
        {
            await _writerMessageDal.AddAsync(model);
            if (await _unitOfWorkDal.SaveChangesAsync() >= 1)
            {
                return true;
            }
            else { return false; }
        }

        public async Task<WriterMessage> GetByIdAsync(int id)
        {
            return await _writerMessageDal.GetByIdAsync(id);
        }

        public async Task<WriterMessage> GetSingleAsync(Expression<Func<WriterMessage, bool>> method)
        {
            return await _writerMessageDal.GetSingleAsync(method);
        }

        public IQueryable<WriterMessage> GetWhere(Expression<Func<WriterMessage, bool>> method)
        {
            return _writerMessageDal.GetWhere(method);
        }

        public async Task<bool> Remove(WriterMessage model)
        {
            _writerMessageDal.Remove(model);
            if (await _unitOfWorkDal.SaveChangesAsync() >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> Update(WriterMessage model)
        {
            _writerMessageDal.Update(model);
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
