using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace ConsoleProject
{
    class Program
    {

        static void Main(string[] args)
        {
            ServiceProject.ServiceCardClient client = new ServiceProject.ServiceCardClient();

            Console.WriteLine("Database Management starting...");
            Console.WriteLine("Database Management successfully started !");
            Console.WriteLine("");
            Console.WriteLine("List of the users : ");

            //Voir la liste des utilisateurs au démarrage
            DisplayUsers();
            TaskChoice();

            Console.WriteLine("Out of the program");
            Console.ReadKey();
        }

        private static void TaskChoice()
        {
            int choiceInt = -1;
            while (choiceInt != 1 & choiceInt != 2 & choiceInt != 3 & choiceInt != 0)
            {
                Console.WriteLine("[1] Add money to User");
                Console.WriteLine("[2] Add print quotas to User");
                Console.WriteLine("[3] Print");
                Console.WriteLine("[0] Exit");
                //Console.WriteLine("[4] Pay in the cafetaria");
                string choice = Console.ReadLine();
                choiceInt = Int32.Parse(choice);
            }
            switch (choiceInt)
            {
                case 1:
                    AddMoney();
                    break;
                case 2:
                    AddQuotas();
                    break;
                case 3:
                    Console.WriteLine("Print ?");
                    break;
                case 4:
                    //PayCafetaria(personID.Id);
                    break;
                case 0:
                    Console.WriteLine("End");
                    return;
            }
            TaskChoice();

        }
        private static int ChooseUserIDorUsername()
        {
            int choiceInt = -1;
            while (choiceInt > 2 | choiceInt < 0)
            {
                Console.WriteLine("[1] Use UserID | [2] Use Username | [0] Go back");
                string choice = Console.ReadLine();
                choiceInt = Int32.Parse(choice);
                DisplayUsers();
            }
            if (choiceInt == 0)
                TaskChoice();

            return choiceInt;
        }
        private static void DisplayUsers()
        {
            ServiceProject.ServiceCardClient client = new ServiceProject.ServiceCardClient();
            var persons = client.GetAllPerson();
            foreach (var person in persons)
            {
                Console.WriteLine(person.Id + "\t" + person.FirstName + "\t " + person.LastName + "      \t" + person.Username + "\t CHF " + person.Balance + ".-");
            }
        }
        private static void DisplayQuotas() 
        {
            ServiceProject.ServiceCardClient client = new ServiceProject.ServiceCardClient();
            var printTypes = client.GetAllPrintType();
            foreach (var printType in printTypes)
            {
                Console.WriteLine("");
                Console.WriteLine(printType.Id + "\t" + printType.Description + " \t " + printType.Color + "\t" + printType.RectoVerso + "\t CHF " + printType.Price + ".-");
            }
        }
        private static void AddMoney()
        {
            ServiceProject.ServiceCardClient client = new ServiceProject.ServiceCardClient();

            int response = ChooseUserIDorUsername();

            //Via UserID
            if (response == 1)
            {
                Person person = null;
                while (person == null)
                {
                    Console.WriteLine("Insert User ID :");
                    string userID = Console.ReadLine();
                    int userIdInt = Int32.Parse(userID);
                    person = client.GetPersonById(userIdInt);
                }
                Console.WriteLine($"Person Username {person.Username} and ID {person.Id}: {person.LastName} {person.FirstName}");
                Console.WriteLine("Actual balance :" + person.Balance);
                Console.WriteLine("How much money do you want to add to this user ?");
                string amount = Console.ReadLine();
                double amountDouble = Double.Parse(amount);
                client.AddMoneyToCard(person.Id, amountDouble);
                Person personRefresh = client.GetPersonById(person.Id);
                Console.WriteLine($"New balance :  {personRefresh.Balance} ");
            }

            //Via Username
            if (response == 2)
            {
                Person person = null;
                while (person == null)
                {
                    Console.WriteLine("Insert Username :");
                    string username = Console.ReadLine();
                    person = client.GetPersonByUsername(username);
                }
                Console.WriteLine($"Person Username {person.Username} and ID {person.Id}: {person.LastName} {person.FirstName}");
                Console.WriteLine("Actual balance :" + person.Balance);
                Console.WriteLine("How much do you want to add to this user ?");
                string amount = Console.ReadLine();
                double amountDouble = Double.Parse(amount);
                client.AddMoneyToCard(person.Id, amountDouble);
                Person personRefresh = client.GetPersonById(person.Id);
                Console.WriteLine($"New balance :  {personRefresh.Balance} ");
            }
        }

        private static void AddQuotas()
        {
            ServiceProject.ServiceCardClient client = new ServiceProject.ServiceCardClient();
            int response = ChooseUserIDorUsername();
            
            //Via UserID
            if (response == 1)
            {
                Person person = null;
                while (person == null)
                {
                    Console.WriteLine("Insert User ID :");
                    string userID = Console.ReadLine();
                    int userIdInt = Int32.Parse(userID);
                    person = client.GetPersonById(userIdInt);
                }
                Console.WriteLine($"Person Username {person.Username} and ID {person.Id}: {person.LastName} {person.FirstName}");
                Console.WriteLine("Actual balance :" + person.Balance);
                PrintType printTypeSpec = null;
                while (printTypeSpec == null)
                {
                    Console.WriteLine("Choose which quotas you want to add ?");
                    DisplayQuotas();
                    string quotaChoice = Console.ReadLine();
                    int quotaChoiceInt = Int32.Parse(quotaChoice);
                    printTypeSpec = client.GetPrintTypeById(quotaChoiceInt);
                }
                Console.WriteLine("How much of this quotas do you want to add? ");
                string numberChoice = Console.ReadLine();
                int numberChoiceInt = Int32.Parse(numberChoice);


                Console.WriteLine($"You have just added {numberChoiceInt} {printTypeSpec.Description} {printTypeSpec.Color} {printTypeSpec.RectoVerso} for {printTypeSpec.Price * numberChoiceInt} to {person.FirstName} {person.LastName}");

            }
            //Via Username
            if (response == 2)
            {
                Person person = null;
                while (person == null)
                {
                    Console.WriteLine("Insert Username :");
                    string username = Console.ReadLine();
                    person = client.GetPersonByUsername(username);
                }
                Console.WriteLine($"Person Username {person.Username} and ID {person.Id}: {person.LastName} {person.FirstName}");
                Console.WriteLine("Actual balance :" + person.Balance);
                PrintType printTypeSpec = null;
                while (printTypeSpec == null)
                {
                    Console.WriteLine("Choose which quotas you want to add ?");
                    DisplayQuotas();
                    string quotaChoice = Console.ReadLine();
                    int quotaChoiceInt = Int32.Parse(quotaChoice);
                    printTypeSpec = client.GetPrintTypeById(quotaChoiceInt);
                }
                Console.WriteLine("How much of this quotas do you want to add? ");
                string numberChoice = Console.ReadLine();
                int numberChoiceInt = Int32.Parse(numberChoice);


                Console.WriteLine($"You have just added {numberChoiceInt} {printTypeSpec.Description} {printTypeSpec.Color} {printTypeSpec.RectoVerso} for {printTypeSpec.Price * numberChoiceInt} to {person.FirstName} {person.LastName}");
            }


        }
       
        
        private static void PayCafetaria()
        {
            /*ServiceProject.ServiceCardClient client = new ServiceProject.ServiceCardClient();
            Person person1 = client.GetPersonById(personID);
            Console.WriteLine("Pay in the cafetaria ?");
            Console.WriteLine("Price of the thing you want to buy");
            string price = Console.ReadLine();
            double priceDouble = Double.Parse(price);
            int result = client.PayCafetaria(personID, priceDouble);
            if (result == 0)
            {
                Console.WriteLine("Payment failure : You don't have enough money");
                Console.WriteLine($"Actual balance : {person1.Balance}");
            }
            else
            {
                person1 = client.GetPersonById(personID);
                Console.WriteLine($"Payment successful ! ");
                Console.WriteLine($"New balance :  {person1.Balance} ");
            }*/
        }


        

 
    }

}
