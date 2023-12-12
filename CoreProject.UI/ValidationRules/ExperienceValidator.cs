using CoreProject.UI.Models;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace CoreProject.UI.ValidationRules
{
    public class ExperienceValidator:AbstractValidator<ExperienceVM>
    {
        public ExperienceValidator() 
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim alanı boş bırakılamaz");
            RuleFor(x=>x.ImageUrl).NotEmpty().WithMessage("Resim alanı boş bırakılamaz");
            RuleFor(x=>x.Description).NotEmpty().WithMessage("Açıklama alanı boş bırakılamaz");
            RuleFor(x=>x.Date).NotEmpty().WithMessage("Date alanı boş bırakılamaz");
        }
    }

}
