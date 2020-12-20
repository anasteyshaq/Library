
namespace Library.Data
{
    public class PublicationInStorage
    {
        public int PublicationId { get; set; }
        public int StorageId { get; set; }
        public Storage Storage { get; set; }
    }
}
