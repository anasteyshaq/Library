using Library.Data.Entities;
using System;
using System.Collections.Generic;

namespace Library.Data
{
    public class Copy
    {
        public int Id { get; set; }
        public int PublicationId { get; set; }
        public DateTime DateInSystem { get; set; }
        public int InventoryNumber { get; set; }
        public List<CopyInForm> CopiesInForm { get; set; }
    }
}
