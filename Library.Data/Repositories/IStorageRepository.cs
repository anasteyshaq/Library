using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Repositories
{
    public interface IStorageRepository
    {
        List<Storage> GetAllStorages(); // получить все публикации
        Storage GetStorageDetails(int StorageId); // получить информацию о Storage по Id
        void CreateStorage(Storage storage); // создать новую Storage
        void UpdateStorage(Storage storage); // обновить запись в БД
        void DeleteStorage(Storage storage); // удалить запись из БД
    }
}
