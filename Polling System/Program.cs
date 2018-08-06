using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polling_System
{
    class Program
    {
        static void Main(string[] args)
        {
            int operationMode = 0;
            do
            {
            input:
                Console.Clear();
                Console.WriteLine("\nWelcome to The Ballot System");
                Console.WriteLine();
                Console.WriteLine("\t1. Admin Module");
                Console.WriteLine("\t2. User Module");
                Console.WriteLine("\t3. Exit");
                Console.WriteLine();
                Console.Write("\tEnter the module you want to enter : ");
                String choice = Console.ReadLine();
                if (new pannel().validate(choice))
                    operationMode = Convert.ToInt32(choice);
                else
                    goto input;

                switch (operationMode)
                {
                    case 1:
                        if (new pannel().chkAdmin())
                            new pannel().adminPannel();
                        else
                            Console.WriteLine("Invalid Password. Please try again");
                        break;
                    case 2:
                        new pannel().userPannel();
                        break;
                    case 3:
                        Console.Write("\n\tAll the Data will be destroyed, are you sure you want to close the Ballot System? (Y/N) : ");
                        String ch = Console.ReadLine();
                        if ((ch.ToLower()).Equals("y"))
                        {
                            Console.WriteLine("\n\tThank You for using the System. Have a good day");
                        }
                        else if ((ch.ToLower()).Equals("n"))
                        {
                            operationMode = 0;
                        }
                        else
                        {
                            Console.WriteLine("\n\tInvalid option to exit.");
                            Console.ReadKey();
                            goto input;
                        }
                        break;
                    default:
                        Console.WriteLine("\n\tInvalid choice entered. Enter proper choice");
                        break;
                }
                Console.ReadKey();
            } while (operationMode != 3);
        }
    }
}