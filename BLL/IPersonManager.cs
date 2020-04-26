using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IPersonManager
    {
        Person GetPersonById(int id);
        Person GetPersonByUsername(string username);
        int AddMoneyToCard(int id, double value);

        int PayCafetaria(int id, double value);
    }
}
