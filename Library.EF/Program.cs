using Library.Data;
using Library.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.EF
{
    class Program
    {
        static void Main(string[] args)
        {
            using (BooksContext db = new BooksContext())
            {
            }
        }
    }
}
