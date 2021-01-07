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
            var res =  _copyRepo.GetCopyDetails(copy.Id); //получение всех записей для экземпляра
            foreach (var p in res.CopiesInForm)
            {
                if (p.ReturnDate == null)
                    return false;
            }    
            return true;
        }
       
    }
}
