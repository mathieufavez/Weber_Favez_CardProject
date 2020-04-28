using BLL;
using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Weber_Favez_CardProject;

namespace WcfServiceWeber_Favez
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "ServiceCard" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez ServiceCard.svc ou ServiceCard.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class ServiceCard : IServiceCard
    {

        public List<Person> GetAllPerson()
        {
            IPersonDB personDb = new PersonDB();
            IPersonManager personManager = new PersonManager(personDb);
            List<Person> persons= personManager.GetAllPersons();
            return persons;
        }

        public Person GetPersonById(int id)
        {
            IPersonDB personDb = new PersonDB();
            IPersonManager personManager = new PersonManager(personDb);
            Person person = personManager.GetPersonById(id);
            return person;
        }

        public Person GetPersonByUsername(string username)
        {
            IPersonDB personDb = new PersonDB();
            IPersonManager personManager = new PersonManager(personDb);
            Person person = personManager.GetPersonByUsername(username);
            return person;
        }

        public int AddMoneyToCard(int personID, double value ) 
        {
            IPersonDB personDb = new PersonDB();
            IPersonManager personManager = new PersonManager(personDb);
            return personManager.AddMoneyToCard(personID, value);
        }

        public int PayCafetaria(int personID, double value) 
        {
            IPersonDB personDb = new PersonDB();
            IPersonManager personManager = new PersonManager(personDb);
            return personManager.PayCafetaria(personID, value);
            
        }

        public List<PrintType> GetAllPrintType() 
        {
            IPrintTypeDB printTypeDb = new PrintTypeDB();
            IPrintTypeManager printTypeManager = new PrintTypeManager(printTypeDb);
            return printTypeManager.GetAllPrintType();
        }

        public PrintType GetPrintTypeById(int id) 
        {
            IPrintTypeDB printTypeDb = new PrintTypeDB();
            IPrintTypeManager printTypeManager = new PrintTypeManager(printTypeDb);
            return printTypeManager.GetPrintTypeById(id);
        }


    }
}
