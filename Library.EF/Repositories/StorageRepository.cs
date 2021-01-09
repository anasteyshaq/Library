using Library.Data;
using Library.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Library.EF.Repositories
{
    public class StorageRepository : IStorageRepository
    {
        public void CreateStorage(Storage storage)
        {
            using (var ctx = new BooksContext())
            {
                ctx.Storages.Add(storage);
                ctx.SaveChanges();
            }
        }

        public void DeleteStorage(Storage storage)
        {
            using (var ctx = new BooksContext())
            {
                ctx.Storages.Remove(storage);
                ctx.SaveChanges();
            }
        }

        public List<Storage> GetAllStorages()
        {
            using (var ctx = new BooksContext())
            {
                return ctx.Storages.Include("PublicationsInStorages").ToList();
            }
        }

        public Storage GetStorageDetails(int StorageId)
        {
            using (var ctx = new BooksContext())
            {
                return ctx.Storages.Include("PublicationsInStorages").SingleOrDefault(x => x.Id == StorageId);
            }
        }

        public void UpdateStorage(Storage storage)
        {
            using (var ctx = new BooksContext())
            {
                ctx.Storages.Attach(storage);
                ctx.Entry(storage).State = EntityState.Modified;
                ctx.SaveChanges();
            }
        }
    }
}
