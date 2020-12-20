using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Data
{
    public class Magazine : Publication
    {
        public string Theme { get; set; }
        public string Periodicity { get; set; }
        public string Specialization { get; set; }
    }
}
