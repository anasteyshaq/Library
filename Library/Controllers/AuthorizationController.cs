using Library.Data;
using Library.Data.Repositories;
using Library.EF;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Library.Controllers
{
    public class AuthorizationController : Controller
    {
        IReaderRepository _readerRepo;

        public AuthorizationController(IReaderRepository readerRepo)
        {
            _readerRepo = readerRepo;
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                // поиск пользователя в бд
                Reader reader = null;
                using (BooksContext ctx = new BooksContext())
                {
                    reader=_readerRepo.GetByLoginData(model.EMail, model.Password);
                }
                if (reader != null)
                {
                    FormsAuthentication.SetAuthCookie(model.EMail, true);
                    return RedirectToAction("Index", "Form");

                }
                else
                {
                    ModelState.AddModelError("", "Користувача з таким логіном та/або паролем не існує");
                }
            }


            return View(model);
        }
     
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(RegistrationModel model)
        {
            if (ModelState.IsValid)
            {
                Reader reader = null;
                using (BooksContext ctx = new BooksContext())
                {
                    _readerRepo.GetByEmail(model.EMail);
                }
                if (reader == null)
                {
                    // создаем нового пользователя
                    using (BooksContext ctx = new BooksContext())
                    {
                        Reader newReader = new Reader()
                        {
                            FirstName = model.FirstName,
                            LastName = model.LastName,
                            EMail = model.EMail,
                            Birthday = model.Birthday,
                            Password = model.Password,
                            PhoneNumber = model.PhoneNumber
                        };

                        ctx.Readers.Add(newReader);
                        ctx.SaveChanges();  
                    }
                    reader = _readerRepo.GetByLoginData(model.EMail, model.Password);
                    // если пользователь удачно добавлен в бд
                    if (reader != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.EMail, true);
                        return RedirectToAction("Login", "Authorization");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Користувач з таким логіном вже існує");
                }
            }

            return View(model);
        }
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Form");
        }

    }
}