using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
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
        //patterns
       public string namePattern = @"^[A-Z]{1}[A-Za-z]{2,}$";
       public string addPattern = @"^[\w]{4,}$";
       public string zipCodePattern = @"^[0-9]{6}$";
       public string contactPattern = @"^(0|\+91)?[789]\d{9}$";
       public string emailPattern = @"^[\w\.-]+@[\w]+\.[a-zA-Z]{2,}$";

       
        public void Add()
        {
            Console.Write("Enter your number :");
            contact = Console.ReadLine();

            Console.Write("Enter your firstname :");
            firstName = Console.ReadLine();

            Console.Write("Enter your lastname :");
            lastName = Console.ReadLine();

            name = firstName + " " + lastName;

            Console.Write("Enter your email :");
            email = Console.ReadLine();

            Console.Write("Enter your city :");
            city = Console.ReadLine();

            Console.Write("Enter your state :");
            state = Console.ReadLine();

            Console.Write("Enter your Zip Code:");
            zipCode = Console.ReadLine();


            //checking validation
            if(!validattion()) { return; }
            
            

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
        
        //show user datiles 
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

        //validation
        public bool validattion()
        {
            bool validatReturn = true;

            if (!Regex.IsMatch(contact, contactPattern))
            {
                Console.WriteLine("Pleas Enter Correct :contact No. ");
                validatReturn = false;
            }
            if (!Regex.IsMatch(firstName, namePattern)) 
            { 
                Console.WriteLine("Pleas Enter Correct :FirstName "); 
                validatReturn = false;
            }
            if (!Regex.IsMatch(lastName, namePattern))
            {
                Console.WriteLine("Pleas Enter Correct :lastName ");
                validatReturn = false;
            }
            if (!Regex.IsMatch(email, emailPattern))
            {
                Console.WriteLine("Pleas Enter Correct :email ");
                validatReturn = false;
            }
            if (!Regex.IsMatch(city, addPattern))
            {
                Console.WriteLine("Pleas Enter Correct :city ");
                validatReturn = false;
            }
            if (!Regex.IsMatch(state, addPattern))
            {
                Console.WriteLine("Pleas Enter Correct :state ");
                validatReturn = false;
            }
            if (!Regex.IsMatch(zipCode, addPattern))
            {
                Console.WriteLine("Pleas Enter Correct :zipCode ");
                validatReturn = false;
            }
            return validatReturn;
        }

       
    }
}

