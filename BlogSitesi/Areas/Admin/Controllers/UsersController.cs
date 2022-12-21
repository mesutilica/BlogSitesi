using BlogSitesi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogSitesi.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    public class UsersController : Controller
    {
        DatabaseContext context = new DatabaseContext(); // veritabanındaki users tablosuna ulaşmak için DatabaseContext sınıfından context isminde bir nesne oluşturduk.
        // GET: UsersController
        public ActionResult Index()
        {
            var kullaniciListesi = context.Users.ToList(); // context nesnesi üzerinden users tablosuna ulaşıp veritabanındaki kayıtları çektik, listeledik.
            return View(kullaniciListesi); // veritabanından çekitiğimiz listeyi ekrana yolladık
        }

        // GET: UsersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            try
            {
                context.Users.Add(user);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Hata Oluştu!");
            }
            return View(user);
        }

        // GET: UsersController/Edit/5
        public ActionResult Edit(int id)
        {
            var user = context.Users.Find(id); // Edit sayfası bizden model olarak içi dolu bir kullanıcı bekliyor
            return View(user);
        }

        // POST: UsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, User user)
        {
            try
            {
                context.Users.Update(user);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Hata Oluştu!");
            }
            return View(user);
        }

        // GET: UsersController/Delete/5
        public ActionResult Delete(int id)
        {
            var user = context.Users.Find(id);
            return View(user);
        }

        // POST: UsersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, User user)
        {
            try
            {
                context.Users.Remove(user);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
