using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Data
{
    public class Book : Publication
    {
        public string Genre { get; set; }
        public string Series { get; set; }
        public string Author { get; set; }
    }
}
