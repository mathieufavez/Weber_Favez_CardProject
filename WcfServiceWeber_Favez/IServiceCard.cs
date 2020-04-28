using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DTO;

namespace WcfServiceWeber_Favez
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IServiceCard" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IServiceCard
    {

        [OperationContract]
        List<Person> GetAllPerson();

        [OperationContract]
        Person GetPersonById(int id);

        [OperationContract]
        Person GetPersonByUsername(string username);

        [OperationContract]
        int AddMoneyToCard(int personID, double value);

        [OperationContract]
        int PayCafetaria(int personID, double value);

        [OperationContract]
        int Print(int printTypeID, int personID, int numberOfCopies);

        [OperationContract]
        List<PrintType> GetAllPrintType();

        [OperationContract]
        PrintType GetPrintTypeById(int id);


    }
}
