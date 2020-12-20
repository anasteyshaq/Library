using System;

namespace Library.Data.Entities
{
    public class CopyInForm
    {
        public int Id { get; set; }
        public int ReaderId { get; set; }
        public int CopyId { get; set; }
        public DateTime DateOfIssue { get; set; } 
        public DateTime? ReturnDate { get; set; }
        public DateTime EstimatedReturnDate { get; set; }
        public Copy Copy { get; set;  }
    }
}
