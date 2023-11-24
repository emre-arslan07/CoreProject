using System.ComponentModel.DataAnnotations;

namespace CoreProject.UI.Areas.Writer.Models
{
    public class UserLoginVM
    {
        [Required(ErrorMessage ="Lütfen Kullanıcı Adınızı Giriniz")]
        public string Username { get; set; }

        [Required(ErrorMessage ="Lütfen şifrenizi giriniz")]
        public string Password { get; set; }
    }
}
