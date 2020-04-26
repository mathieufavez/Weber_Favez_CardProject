using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IPersonDB
    {
        Person GetPersonById(int id);
        Person GetPersonByUsername(string username);
        int UpdatePersonBalance(Person person);
    }
}
