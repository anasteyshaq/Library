using Library.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Models
{
    public class CreateCatalogModel
    {
        public List<Publication> Publications { get; set; }
        public List<bool> Select { get; set; }
    }
}