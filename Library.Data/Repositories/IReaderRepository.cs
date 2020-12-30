using Library.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Repositories
{
    public interface IReaderRepository
    {
        Reader Get(int ReaderId);
        void CreateReader(Reader reader);
        void UpdateReader(Reader reader);
        Reader GetByLoginData(string Email, string Password);
        Reader GetByEmail(string Email);
    }
}
