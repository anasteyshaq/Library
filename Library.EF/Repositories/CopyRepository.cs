using Library.Data;
using Library.Data.Entities;
using Library.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.EF.Repositories
{
    public class CopyRepository : ICopyRepository
    {
        #region ICopyRepository Members

        public Copy GetCopyDetails(int CopyId)
        {
            using (var ctx = new BooksContext())
            {
                return ctx.Copies.Include("CopiesInForm").SingleOrDefault(x => x.Id == CopyId);
            }
        }
        public void CreateCopy(Copy copy)
        {
            using (var ctx = new BooksContext())
            {
                ctx.Copies.Add(copy);
                ctx.SaveChanges();
            }
        }

        public List<Copy> GetAllCopiesByPublicationId(int PublicationId)
        {
            using (var ctx = new BooksContext())
            {
                return ctx.Copies.Where(x => x.PublicationId == PublicationId).ToList();
            }
            
        }
        
        public void CreateCopyInForm(int ReaderId, int CopyId)
        {
            using (var ctx = new BooksContext())
            {
                CopyInForm copyInForm = new CopyInForm()
                {
                    CopyId = CopyId,
                    ReaderId = ReaderId,
                    DateOfIssue = DateTime.Today,
                    ReturnDate = null,
                    EstimatedReturnDate = DateTime.Today.AddDays(14)
                };
                ctx.CopiesinForms.Add(copyInForm);
                ctx.SaveChanges();
            }
        }
        
        public CopyInForm GetCopyInForm(int ReaderId, int CopyId)
        {
            using (var ctx = new BooksContext())
            {
                return ctx.CopiesinForms.Where(x => x.ReaderId == ReaderId &&
                x.CopyId == CopyId).FirstOrDefault();
            }
        }
        #endregion
    }
}
