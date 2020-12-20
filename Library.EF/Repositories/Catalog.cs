using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Data;
using Library.Data.Repositories;

namespace Library.EF.Repositories
{
    public class Catalog : ICatalog
    {
        #region ICatalog Members

        public List<Publication> GetAllPublications()
        {
            using (var ctx = new BooksContext())
            {
                return ctx.Publications.ToList();
            }
        }

        // ????????????????????????????????
        public Publication GetPublicationDetails(int PublicationId)
        {
            using (var ctx = new BooksContext())
            {
                bool newspapers = ctx.Newspapers.Where(n => n.Id == PublicationId).Any();
                bool books = ctx.Books.Where(b => b.Id == PublicationId).Any();
                bool magazines = ctx.Magazines.Where(m => m.Id == PublicationId).Any();
                if (newspapers == true)
                {
                    return ctx.Publications.Include("Newspapers").First(x => x.Id == PublicationId);
                }
                else if (books == true)
                {
                    return ctx.Publications.Include("Books").First(x => x.Id == PublicationId);
                }
                else if (magazines == true)
                {
                    return ctx.Publications.Include("Magazines").First(x => x.Id == PublicationId);
                }
                else return null;
            }
        }

        public void CreatePublication(Publication publication)
        {
            using (var ctx = new BooksContext())
            {
                ctx.Publications.Add(publication);
                ctx.SaveChanges();
            }
        }

        public void UpdatePublication(Publication publication)
        {
            using (var ctx = new BooksContext())
            {
                ctx.Publications.Attach(publication);
                ctx.Entry(publication).State = EntityState.Modified;
                ctx.SaveChanges();
            }
        }

        public void DeletePublication(Publication publication)
        {
            using (var ctx = new BooksContext())
            {
                ctx.Publications.Remove(publication);
                ctx.SaveChanges();
            }
        }

        #endregion
    }
}
