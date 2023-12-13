using CoreProject.UI.Models;
using FluentValidation;

namespace CoreProject.UI.ValidationRules
{
    public class AboutValidator:AbstractValidator<AboutVM>
    {
        public AboutValidator()
        {
            RuleFor(x=>x.Title).NotEmpty().WithMessage("Başlık alanı boş bırakılamaz");
            RuleFor(x=>x.Age).NotEmpty().WithMessage("Yaş alanı boş bırakılamaz");
            RuleFor(x=>x.Mail).NotEmpty().WithMessage("Mail alanı boş bırakılamaz");
            RuleFor(x=>x.Phone).NotEmpty().WithMessage("Telefon alanı boş bırakılamaz");
            RuleFor(x=>x.Address).NotEmpty().WithMessage("Adres alanı boş bırakılamaz");
            RuleFor(x=>x.ImageUrl).NotEmpty().WithMessage("Resim alanı boş bırakılamaz");
            RuleFor(x=>x.Description).NotEmpty().WithMessage("Açıklama alanı boş bırakılamaz");
        }
    }
}
