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
            foreach (var publication in model.Publications)
            {
                var parameters = new PublicationParameters()
                {
                    Publication = publication,
                    Select = model.Select
                };
                if (parameters.Select == true)
                {
                    var copies = _copyRepo.GetAllCopiesByPublicationId(publication.Id);
                    if (copies != null)
                    {
                        foreach (var copy in copies)
                        {
                            var check = _copyServ.CheckIfAvailable(copy);
                            if(check == true)
                            {
                                selectedPublications.Add(copy);
                            }
                        }
                    }
                }
            }
            return RedirectToAction("Application", new { copies = selectedPublications });
        }

    }
}
