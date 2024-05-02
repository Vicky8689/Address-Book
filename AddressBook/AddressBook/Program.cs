using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    
    internal class Program : Operations   //inharit Operations for call static methods
    {
        static void Main(string[] args)
        {
        Options:
            Console.WriteLine("Chose the option to perform operation on AddressBook:-");
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("Enter 1 for add new Contact to AdderssBook");
            Console.WriteLine("Enter 2 for print all Contacts");
            Console.WriteLine("Enter 3 for search Contacts by Name");
            Console.WriteLine("Enter 4 for search and edit by name");
            Console.WriteLine("Enter 5 for Quite");

            try
            {
                Console.Write("Enter Option :");
                int op = Convert.ToInt32(Console.ReadLine());
                Operations obj = new Operations();
                switch (op)
                {
                    case 1:
                        obj.Add();
                        goto Options;
                        break;
                    case 2:
                        showDatils();
                        goto Options;
                        break;
                    case 3:
                        Console.WriteLine("Enter User Name");
                        string enterName = Console.ReadLine();
                        showDatils(enterName);
                        goto Options;
                        break;
                    case 4:
                        Console.WriteLine("Enter User Name to edit");
                        string Name = Console.ReadLine();
                        bool check =  showDatils(Name);
                        if (check)
                        {  
                        editDatils(Name);
                        }
                        goto Options;
                    case 5:
                        Console.WriteLine("Good byy....");
                        break;
                    default: 
                        goto Options;
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

        }
    }
}
