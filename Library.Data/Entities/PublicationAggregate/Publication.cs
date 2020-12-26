using System;
using System.ComponentModel.DataAnnotations;

namespace Library.Data
{
    public class Publication
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Publisher { get; set; }
        public int? NofPages { get; set; }
        [DataType(DataType.Date)]
        public DateTime? PublicationDate { get; set; }
    }
}
