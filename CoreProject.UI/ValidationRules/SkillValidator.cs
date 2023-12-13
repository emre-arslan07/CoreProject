using CoreProject.UI.Models;
using FluentValidation;

namespace CoreProject.UI.ValidationRules
{
    public class SkillValidator:AbstractValidator<SkillVM>
    {
        public SkillValidator()
        {
            RuleFor(x=>x.Title).NotEmpty().WithMessage("Başlık alanı boş bıraklamaz");
            RuleFor(x=>x.Value).NotEmpty().WithMessage("Değer alanı boş bıraklamaz");
        }
    }
}
