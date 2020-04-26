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

            string cardNumber;
            int cardNumberInt=-1;
      
                Console.WriteLine("Connection");
       
                    while (cardNumberInt != 0)
                    {
                        Console.WriteLine("Card number :");
                        cardNumber = Console.ReadLine();
                        cardNumberInt = Int32.Parse(cardNumber);

                        Person personID = client.GetPersonById(cardNumberInt);

                        if (personID != null)
                        {
                            Console.WriteLine($"Person Username {personID.Username} and ID {cardNumberInt}: {personID.LastName} {personID.FirstName} is connected ");
                            Console.WriteLine("Actual balance :" + personID.Balance);

                            Console.WriteLine("[1] Add money to your account");
                            Console.WriteLine("[2] Add print quotas");
                            Console.WriteLine("[3] Print");
                            Console.WriteLine("[4] Pay in the cafetaria");
                            string choice = Console.ReadLine();
                            int choiceInt = Int32.Parse(choice);

                            switch (choiceInt)
                            {
                                case 1:
                                    Console.WriteLine("How much do you want to add ?");
                                    string value = Console.ReadLine();
                                    double valueDouble = Double.Parse(value);
                                    client.AddMoneyToCard(personID.Id, valueDouble);
                                    Person person = client.GetPersonById(cardNumberInt);
                                    Console.WriteLine($"New balance :  {person.Balance} ");
                                    break;
                                case 2:
                                    Console.WriteLine("Add quotas");
                                    break;
                                case 3:
                                    Console.WriteLine("Print ?");
                                    break;
                                case 4:
                                    Console.WriteLine("Pay in the cafetaria ?");
                                    Console.WriteLine("Price of the thing you want to buy");
                                    string price = Console.ReadLine();
                                    double priceDouble = Double.Parse(price);
                                    int result = client.PayCafetaria(personID.Id, priceDouble);
                                    if (result == 0)
                                    {
                                        Console.WriteLine("You don't have enough money");
                                        Console.WriteLine($"Actual balance : {personID.Balance}");
                                    }
                                    Person person1 = client.GetPersonById(cardNumberInt);
                                    Console.WriteLine($"New balance :  {person1.Balance} ");
                            break;
                                default:
                                    Console.WriteLine("End");
                                    break;
                            }
                        }
                        else
                            Console.WriteLine("User doesn't exist");
                    }

                    Console.WriteLine("Out of the program");
          
            Console.ReadKey();
        }
    }
}
