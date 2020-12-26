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
        public List<Copy> GetAllCopies()
        {
            using (var ctx = new BooksContext())
            {
                return ctx.Copies.ToList();
            }
        }

        public Copy GetCopyDetails(int CopyId)
        {
            using (var ctx = new BooksContext())
            {
                return ctx.Copies.SingleOrDefault(x => x.Id == CopyId);
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

        public void UpdateCopy(Copy copy)
        {
            using (var ctx = new BooksContext())
            {
                ctx.Copies.Attach(copy);
                ctx.Entry(copy).State = EntityState.Modified;
                ctx.SaveChanges();
            }
        }

        public void DeleteCopy(Copy copy)
        {
            using (var ctx = new BooksContext())
            {
                ctx.Copies.Remove(copy);
                ctx.SaveChanges();
            }
        }

        public List<CopyInForm> GetAllCopiesInForm(int CopyId)
        {
            using (var ctx = new BooksContext())
            {
                return ctx.CopiesinForms.OrderByDescending(x=>x.ReturnDate).
                    Where(x => x.CopyId == CopyId).ToList();
            }
            // выборка сортированных по дате возвращения записей экземпляра в формулярах по его ай ди.
        }
        public List<Copy> GetAllCopiesByPublicationId(int PublicationId)
        {
            using (var ctx = new BooksContext())
            {
                return ctx.Copies.Where(x => x.PublicationId == PublicationId).ToList();
            }
            // выборка сортированных по дате возвращения записей экземпляра в формулярах по его ай ди.
        }
        #endregion
    }
}
