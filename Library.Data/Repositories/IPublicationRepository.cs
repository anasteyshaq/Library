using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Repositories
{
    public interface IPublicationRepository
    {
        List<Publication> GetAllPublications(); // получить все публикации
        Publication GetPublicationDetails(int? PublicationId); // получить информацию о публикации по Id
        void CreatePublication(Publication publication); // создать новую публикацию
        void UpdatePublication(Publication publication); // обновить запись в БД
        void DeletePublication(Publication publication); // удалить запись из БД
        List<Publication> GetAvailablePublications();
    }
}
