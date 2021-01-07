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
    }
}
