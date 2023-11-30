using CoreProject.Entity.Concrete;
using CoreProject.UI.Areas.Writer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreProject.UI.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userValues = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditVM userEditVM = new UserEditVM();
            userEditVM.Name = userValues.Name;
            userEditVM.Surname = userValues.Surname;
            userEditVM.PictureURL = userValues.ImageUrl;
            return View(userEditVM);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserEditVM userEditVM)
        {
            var uservalues = await _userManager.FindByNameAsync(User.Identity.Name);
            uservalues.Name = userEditVM.Name;
            uservalues.Surname = userEditVM.Surname;
            if (userEditVM.Picture!=null) 
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(userEditVM.Picture.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = resource + "/wwwroot/userimage/" + imageName;
                var stream=new FileStream(saveLocation,FileMode.Create);
                await userEditVM.Picture.CopyToAsync(stream);
                uservalues.ImageUrl = imageName;
            }
            else
            {
                uservalues.ImageUrl = uservalues.ImageUrl;
            }
            if (userEditVM.Password==null || userEditVM.PasswordConfirm==null)
            {
                uservalues.PasswordHash = uservalues.PasswordHash;
            }
            else
            {               
                uservalues.PasswordHash = _userManager.PasswordHasher.HashPassword(uservalues, userEditVM.Password);
            }
                var result = await _userManager.UpdateAsync(uservalues);
            
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}
