using Library.Data.Entities;
using System;
using System.Collections.Generic;

namespace Library.Data
{
    public class Reader
    {
        public int Id { get; set; }
        public int CopyInFormId { get; set; }
        public int TicketNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Birthday { get; set; }
        public string EMail { get; set; } 
    }
}
