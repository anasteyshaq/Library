using Library.Data;
using Library.Data.Repositories;
using Library.Domain.Interfaces;
using System;
using System.Linq;

namespace Library.Domain.DefaultImplementations
{
    public class CopyService : ICopyService
    {
        ICopyRepository _copyRepo;
        public CopyService(ICopyRepository copyRepo)
        {
            _copyRepo = copyRepo;
        }
        public bool CheckIfAvailable(Copy copy)
        {
            var res = _copyRepo.GetAllCopiesInForm(copy.Id).First(); //получение всех записей для экземпляра
            return (res.ReturnDate != null);
        }
    }
}
