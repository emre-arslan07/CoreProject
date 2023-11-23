using CoreProject.UI.Areas.Writer.Models;
using FluentValidation;

namespace CoreProject.UI.ValidationRules
{
    public class UserRegisterValidator:AbstractValidator<UserRegisterVM>
    {
        public UserRegisterValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Lütfen adınızı giriniz");
            RuleFor(x=>x.Surname).NotEmpty().WithMessage("Lütfen soyadınızı giriniz");
            RuleFor(x=>x.UserName).NotEmpty().WithMessage("Lütfen kullanıcı adınızı giriniz");
            RuleFor(x=>x.Password).NotEmpty().WithMessage("Lütfen şifrenizi giriniz");
            RuleFor(x=>x.ConfirmPassword).NotEmpty().WithMessage("Lütfen şifrenizi tekrar giriniz");
            RuleFor(x=>x.Mail).NotEmpty().WithMessage("Lütfen mail adresinizi giriniz");
            //RuleFor(x => x.Password).NotEqual(x => x.ConfirmPassword).WithMessage("Şifreler uyuşmuyor");
        }
    }
}
