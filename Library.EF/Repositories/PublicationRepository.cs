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
    public class PublicationRepository : IPublicationRepository
    {
        #region ICatalog Members

        public List<Publication> GetAllPublications()
        {
            using (var ctx = new BooksContext())
            {
                return ctx.Publications.ToList();
            }
        }

        public Publication GetPublicationDetails(int? PublicationId)
        {
            using (var ctx = new BooksContext())
            {
                return ctx.Publications.Single(x => x.Id == PublicationId);
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
