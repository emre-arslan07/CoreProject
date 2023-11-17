using CoreProject.UI.Models;
using FluentValidation;

namespace CoreProject.UI.ValidationRules
{
    public class PortfolioValidator : AbstractValidator<PortfolioVM>
    {
        public PortfolioValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Proje Adı Boş Geçilemez");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Görsel Alanı Boş Geçilemez");
            RuleFor(x => x.ImageUrl2).NotEmpty().WithMessage("Görsel Alanı 2 Boş Geçilemez");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Fiyat Alanı Boş Geçilemez");
            RuleFor(x => x.Value).NotEmpty().WithMessage("Değer Alanı Boş Geçilemez");
            RuleFor(x => x.Name).MinimumLength(5).WithMessage("Proje Adı En Az 5 Karakterden Oluşmalı");
            RuleFor(x => x.Name).MaximumLength(100).WithMessage("Proje Adı En Fazla 100 Karakterden Oluşmalı");
        }
    }
}
