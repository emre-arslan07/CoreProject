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
    public class TestimonialManager : ITestimonialService
    {
        private readonly ITestimonialDal _testimonialDal;
        private readonly IUnitOfWorkDal _unitOfWorkDal;

        public TestimonialManager(ITestimonialDal testimonialDal, IUnitOfWorkDal unitOfWorkDal)
        {
            _testimonialDal = testimonialDal;
            _unitOfWorkDal = unitOfWorkDal;
        }

        public async Task<bool> AddAsync(Testimonial model)
        {
            await _testimonialDal.AddAsync(model);
            if (await _unitOfWorkDal.SaveChangesAsync() >= 1)
            {
                return true;
            }
            else { return false; }
        }

        public async Task<Testimonial> GetByIdAsync(int id)
        {
            return await _testimonialDal.GetByIdAsync(id);
        }

        public async Task<Testimonial> GetSingleAsync(Expression<Func<Testimonial, bool>> method)
        {
            return await _testimonialDal.GetSingleAsync(method);
        }

        public IQueryable<Testimonial> GetWhere(Expression<Func<Testimonial, bool>> method)
        {
            return _testimonialDal.GetWhere(method);
        }

        public async Task<bool> Remove(Testimonial model)
        {
            _testimonialDal.Remove(model);
            if (await _unitOfWorkDal.SaveChangesAsync() >= 1)
            {
                return true;
            }
            else
            {
                return false;
            };
        }

        public async Task<bool> Update(Testimonial model)
        {
            _testimonialDal.Update(model);
            if (await _unitOfWorkDal.SaveChangesAsync() >= 1)
            {
                return true;
            }
            else
            {
                return false;
            };
        }
    }
}
