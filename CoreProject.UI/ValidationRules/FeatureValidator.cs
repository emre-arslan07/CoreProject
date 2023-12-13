using CoreProject.UI.Models;
using FluentValidation;

namespace CoreProject.UI.ValidationRules
{
    public class FeatureValidator:AbstractValidator<FeatureVM>
    {
        public FeatureValidator()
        {
            RuleFor(x=>x.Header).NotEmpty().WithMessage("Başlık alanı boş bırakılamaz");
            RuleFor(x=>x.Name).NotEmpty().WithMessage("İsim alanı boş bırakılamaz");
            RuleFor(x=>x.Title).NotEmpty().WithMessage("Unvan alanı boş bırakılamaz");
        }
    }
}
