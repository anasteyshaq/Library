using Library.Data.Repositories;
using System.Web.Mvc;
using Library.Models;
using System.Linq;
using Library.Data;
using System.Collections.Generic;
using Library.Domain.DefaultImplementations;
using Library.Domain.Interfaces;
using Library.Data.Entities;

namespace Library.Controllers
{
    public class FormController : Controller
    {
        IPublicationRepository _catalog;
        ICopyService _copyServ;
        ICopyRepository _copyRepo;
        IReaderRepository _readerRepo;
        IStorageRepository _storageRepo;

        public FormController(IPublicationRepository catalog,
            ICopyService copyServ,
            ICopyRepository copyRepo,
            IReaderRepository readerRepo,
            IStorageRepository storageRepo)
        {
            _catalog = catalog;
            _copyServ = copyServ;
            _copyRepo = copyRepo;
            _readerRepo = readerRepo;
            _storageRepo = storageRepo;
        }
    
        [HttpGet]
        public ActionResult Index()
        {
            var publications = _catalog.GetAllPublications();
            var model = new CreateCatalogModel()
            {
                Publications = publications
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult CreateApplication(CreateCatalogModel model)
        {
            var selectedPublications = new List<Copy>();
            for (int i = 0; i < model.Publications.Count; i++)
            {
                var parameters = new PublicationParameters()
                {
                    Publication = model.Publications[i],
                    Select = model.Select[i]
                };
                if (parameters.Select == true)
                {
                    var copies = _copyRepo.GetAllCopiesByPublicationId(model.Publications[i].Id);
                    if (copies != null)
                    {
                        foreach (var copy in copies)
                        {
                            var check = _copyServ.CheckIfAvailable(copy);
                            if(check == true)
                            {
                                selectedPublications.Add(copy);
                                break;
                            }
                        }
                    }
                }
            }
            return Application(selectedPublications);// RedirectToAction("Application", new { copies = selectedPublications });
        }
        [HttpGet]
        public ActionResult Application(List<Copy> copies)
        {
            Reader r = null;
            List<CopyInForm> copiesInForm = new List<CopyInForm>();

            if (User.Identity.IsAuthenticated)
            {
                r = _readerRepo.GetByEmail(User.Identity.Name);
            }
            else
            {
                return RedirectToAction("Login", "Authoriza" +
                    "tion");
            }
            foreach (var c in copies)
            {
                _copyRepo.CreateCopyInForm(r.Id, c.Id);
                copiesInForm.Add(_copyRepo.GetCopyInForm(r.Id, c.Id));
            }

            var publications = new List<Publication>();
            for (int i = 0; i < copies.Count; i++)
            {
                var publication = _catalog.GetPublicationDetails(copies[i].PublicationId);
                publications.Add(publication);
            }
            var model = new CreateApplicationModel
            {
                SelectedPublications = publications,
                CopiesInForm = copiesInForm
            };

            return View("Application",model);
        }
        [HttpGet]
        public ActionResult Info(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            else
            {
                var shtuka = _catalog.GetPublicationDetails(id);
                return View("Info","Form",shtuka);
            }

        }
    }
}
