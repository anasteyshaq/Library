using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Data
{
    public class Newspaper : Publication
    {
        public string Theme { get; set; }
        public string Periodicity { get; set; }
        public int? AgeTo { get; set; }
        public string NewspaperFormat { get; set; }
        public string Quality { get; set; }
    }
}
