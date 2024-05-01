using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    internal class Operations
    {
       public static List<User> usersList = new List<User>();
       private string contact;
       private string firstName;
       private string lastName;
       private string name;
       private string email;
       private string city;
       private string state;
       private string zipCode;
       
        public  void Add()
        {

            Console.Write("Enter your number :");
            contact = Console.ReadLine();
            
            Console.Write("Enter your firstname :");
            firstName = Console.ReadLine();

            Console.Write("Enter your lastname :");
            lastName = Console.ReadLine();

            name = firstName+" "+lastName;

            Console.Write("Enter your email :");
            email = Console.ReadLine();

            Console.Write("Enter your city :");
            city = Console.ReadLine();
            
            Console.Write("Enter your state :");
            state = Console.ReadLine();

            Console.Write("Enter your Zip Code:");
            zipCode = Console.ReadLine();


            User user =new User();
            //add user datils 
            user.contact = contact;
            user.name = name;
            user.email = email;
            user.city = city;
            user.zipCode = zipCode;
            user.state = state;
            //add user in list
            usersList.Add(user); 
        }

        public void ShowDatils()
        {
            foreach(User i in  usersList) 
            {
                Console.WriteLine("Name        :" + i.name);
                Console.WriteLine("Contact No. :" + i.contact);
                Console.WriteLine("Email       :" + i.email);
                Console.WriteLine("City        :" + i.city);
                Console.WriteLine("state       :" + i.state);
                Console.WriteLine("ZipCode     :" + i.zipCode);
            }
        }

       
    }
}
