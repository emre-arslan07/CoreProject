using CoreProject.UI.Models;
using FluentValidation;

namespace CoreProject.UI.ValidationRules
{
    public class SocialMediaController:AbstractValidator<SocialMediaVM>
    {
        public SocialMediaController()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Başlık alanı boş bırakılamaz");
            RuleFor(x=>x.Url).NotEmpty().WithMessage("Link alanı boş bırakılamaz");
            RuleFor(x=>x.Icon).NotEmpty().WithMessage("İkon alanı boş bırakılamaz");
        }
    }
}
