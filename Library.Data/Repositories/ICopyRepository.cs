using Library.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Repositories
{
    public interface ICopyRepository
    {
        CopyInForm GetCopyInForm(int ReaderId, int CopyId);
        List<Copy> GetAllCopiesByPublicationId(int PublicationId);
        Copy GetCopyDetails(int CopyId); // получить информацию о Copy по Id
        void CreateCopy(Copy copy); // создать новую Copy
        void CreateCopyInForm(int ReaderId, int CopyId);
    }
}
