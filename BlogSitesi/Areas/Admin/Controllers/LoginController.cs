using BlogSitesi.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BlogSitesi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        private readonly DatabaseContext _context;

        public LoginController(DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SignOutAsync()
        {
            await HttpContext.SignOutAsync(); // Kullanıcıya çıkış yaptırdık
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> IndexAsync(string email, string sifre)
        {
            var kullanici = await _context.Users.FirstOrDefaultAsync(k => k.IsActive && k.Email == email && k.Password == sifre);
            if (kullanici == null)
            {
                TempData["mesaj"] = "Giriş Başarısız!";
            }
            else
            {
                var haklar = new List<Claim>() // Claim = hak demek, kullanıcının admin ekranına erişim hakkı
                {
                    new Claim(ClaimTypes.Email, kullanici.Email) // yeni bir hak tanımladık
                };
                var kullaniciKimligi = new ClaimsIdentity(haklar, "Login"); // tc kimlik gibi bir sistem ekledik
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(kullaniciKimligi); // ClaimsPrincipal = hak kuralları
                await HttpContext.SignInAsync(claimsPrincipal); // SignInAsync metoduyla sisteme kullanıcıyı giriş yaptırdık
                return Redirect("/Admin");
            }
            return View();
        }
    }
}
