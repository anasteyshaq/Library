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
        #endregion
    }
}
