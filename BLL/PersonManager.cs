using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PersonManager : IPersonManager
    {
        private IPersonDB PersonDb { get; }

        public PersonManager(IPersonDB personDb)
        {
            PersonDb = personDb;
        }

        public List<Person> GetAllPersons() 
        {
            return PersonDb.GetAllPersons();
        }


        public Person GetPersonById(int id)
        {
            return PersonDb.GetPersonById(id);
        }
        public Person GetPersonByUsername(string username)
        {
            return PersonDb.GetPersonByUsername(username);
        }

        public int AddMoneyToCard(int id, double value) {
            Person person = GetPersonById(id);
            person.Balance += value;
            return PersonDb.UpdatePersonBalance(person);
        }

        public int PayCafetaria(int id, double value) {
            Person person = GetPersonById(id);
            if (person.Balance >= value)
            {
                person.Balance -= value;
                return PersonDb.UpdatePersonBalance(person);
            }
            else
                return 0;
            
        }


    }
}
