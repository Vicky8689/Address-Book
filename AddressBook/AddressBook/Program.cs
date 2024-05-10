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
            Console.WriteLine("Enter 2 for print all Users Datils ");
            Console.WriteLine("Enter 3 for search Users Datils by Contact");
            Console.WriteLine("Enter 4 for search and edit by Contact");
            Console.WriteLine("Enter 5 for delet by contact");
            Console.WriteLine("Enter 6 for Quite");

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
                        Console.WriteLine("Enter User Contact :");
                        string Contact = Console.ReadLine();
                        showDatils(Contact);
                        goto Options;
                        break;
                    case 4:
                        Console.WriteLine("Enter User Contact to edit");
                        string edit_Contact = Console.ReadLine();
                        bool check =  showDatils(edit_Contact);
                        if (check)
                        {  
                        editDatils(edit_Contact);
                        }
                        goto Options;
                    case 5:
                        Console.WriteLine("Enter contact no. to delete");
                        string contact = Console.ReadLine();
                        deleteData(contact);
                        goto Options;
                        break;
                    case 6:
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
