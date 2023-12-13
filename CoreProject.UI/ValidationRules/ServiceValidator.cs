using CoreProject.UI.Models;
using FluentValidation;

namespace CoreProject.UI.ValidationRules
{
    public class ServiceValidator:AbstractValidator<ServiceVM>
    {
        public ServiceValidator()
        {
            RuleFor(x=>x.Title).NotEmpty().WithMessage("Başlık alanı boş bırakılamaz");
            RuleFor(x=>x.ImageUrl).NotEmpty().WithMessage("Resim alanı boş bırakılamaz");
        }
    }
}
