using CoreProject.UI.Models;
using FluentValidation;

namespace CoreProject.UI.ValidationRules
{
    public class TestimonialValidator:AbstractValidator<TestimonialVM>
    {
        public TestimonialValidator()
        {
            RuleFor(x=>x.ClientName).NotEmpty().WithMessage("İsim alanı boş bırakılamaz");
            RuleFor(x=>x.Company).NotEmpty().WithMessage("Şirket alanı boş bırakılamaz");
            RuleFor(x=>x.ImageUrl).NotEmpty().WithMessage("Resim alanı boş bırakılamaz");
            RuleFor(x=>x.Title).NotEmpty().WithMessage("Unvan alanı boş bırakılamaz");
            RuleFor(x=>x.Comment).NotEmpty().WithMessage("Yorum alanı boş bırakılamaz");
        }
    }
}
