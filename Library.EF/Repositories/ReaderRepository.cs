using Library.Data;
using Library.Data.Repositories;
using System.Data.Entity;
using System.Linq;

namespace Library.EF.Repositories
{
    public class ReaderRepository : IReaderRepository
    {
        #region IReader Members
        public void CreateReader(Reader reader)
        {
            using (var ctx = new BooksContext())
            {
                ctx.Readers.Add(reader);
                ctx.SaveChanges();
            }
        }

        public void UpdateReader(Reader reader)
        {
            using (var ctx = new BooksContext())
            {
                ctx.Readers.Attach(reader);
                ctx.Entry(reader).State = EntityState.Modified;
                ctx.SaveChanges();
            }
        }

        public Reader Get(int ReaderId)
        {
            using (var ctx = new BooksContext())
            {
                return ctx.Readers.First(x => x.Id == ReaderId);
            }
        }
        #endregion
    }
}
