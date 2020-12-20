using System;
using System.Collections.Generic;

namespace Library.Data
{
    public class Publication
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Publisher { get; set; }
        public int? NofPages { get; set; }
        public DateTime? PublicationDate { get; set; }
    }
}
