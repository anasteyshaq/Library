using Library.Data;
using Library.Data.Repositories;
using Library.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.DefaultImplementations
{
    public class PublicationService:IPublicationService
    {
        IPublicationRepository _publicationRepo;
        ICopyRepository _copyRepo;
        ICopyService _copyService;
        public PublicationService(IPublicationRepository publicationRepo,
            ICopyRepository copyRepo,
            ICopyService copyService)
        {
            _publicationRepo = publicationRepo;
            _copyRepo = copyRepo;
            _copyService = copyService;
        }
        public bool CheckIfAvailable(Publication publication)
        {
            var allCopies = _copyRepo.GetAllCopiesByPublicationId(publication.Id);
            foreach (var copy in allCopies)
            {
                var check = _copyService.CheckIfAvailable(copy);
                if (check == true)
                    return true;
            }
            return false;
        }
    }
}
