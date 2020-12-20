using System.Collections.Generic;

namespace Library.Data
{
    public class Storage
    {
        public int Id { get; set; }
        public string Sector { get; set; }
        public int ShelfNumber { get; set; }
        public int RowNumber { get; set; }
        public int ColumnNumber { get; set; }
        public int FloorNumber { get; set; }
        public int WarehouseNumber { get; set; }
        public int CellNumber { get; set; }
        public string SetNumber { get; set; }
        public List<PublicationInStorage> PublicationsInStorages { get; set; }
    }
}
