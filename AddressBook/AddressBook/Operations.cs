using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AddressBook
{
    abstract class methods
    {
        public abstract void Add();

    }
    internal class Operations: methods     //Inherit Abstract class methods
    {
       public static List<User> usersList = new List<User>();
      private string firstName,lastName;
        //patterns
       public string namePattern = @"^[A-Z]{1}[A-Za-z]{2,}$";
       public string addPattern = @"^[\w]{4,}$";
       public string zipCodePattern = @"^[0-9]{6}$";
       public string contactPattern = @"^(0|\+91)?[789]\d{9}$";
       public string emailPattern = @"^[\w\.-]+@[\w]+\.[a-zA-Z]{2,}$";

        
        public override void Add()
        {

            User user = new User();
            Console.Write("Enter your number :");
            user.contact = Console.ReadLine();
            //checking user is present or not
            foreach(User i in usersList)
            {
                if (i.contact.Equals(user.contact))
                {
                    Console.WriteLine("User already exite please try again..");
                    return; 
                }
            }
            Console.Write("Enter your firstname :");
            firstName = Console.ReadLine();

            Console.Write("Enter your lastname :");
            lastName = Console.ReadLine();

            user.name = firstName + " " + lastName;

            Console.Write("Enter your email :");
            user.email = Console.ReadLine();

            Console.Write("Enter your city :");
            user.city = Console.ReadLine();

            Console.Write("Enter your state :");
            user.state = Console.ReadLine();

            Console.Write("Enter your Zip Code:");
            user.zipCode = Console.ReadLine();

            //checking validation
            if(!validattion(user)) { return; }
            //add user in list

            usersList.Add(user);
            Bookdata.AddDataTotxt(usersList);
        }
        
        //show user datiles 
        public static void showDatils()
        {
            using (FileStream sf = new FileStream(@"D:\My_Address_Book\AddressBookData.txt", FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(sf))
                {
                    string line = "";
                    while ((line = sr.ReadLine()) != null)  //reade line and store in line variable if line is not null the retun TRUE
                    {                     
                            Console.WriteLine(line);    
                    }
                }
            }

            //if (usersList.Count()==0) 
            //{
            //    Console.WriteLine("Empty AddressBook");
            //    return;
            //}
            //Console.WriteLine("---------------------ALL CONTACTS---------------------------------");
            //foreach (User i in  usersList) 
            //{
            //    Console.WriteLine("Name        :" + i.name);
            //    Console.WriteLine("Contact No. :" + i.contact);
            //    Console.WriteLine("Email       :" + i.email);
            //    Console.WriteLine("City        :" + i.city);
            //    Console.WriteLine("state       :" + i.state);
            //    Console.WriteLine("ZipCode     :" + i.zipCode);
            //    Console.WriteLine("------------------------------------------------------------------");
            //}
        }

        //validation    --Completed
        public bool validattion(User user)
        {
            bool validatReturn = true;

            if (!Regex.IsMatch(user.contact, contactPattern))
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
            if (!Regex.IsMatch(user.email, emailPattern))
            {
                Console.WriteLine("Pleas Enter Correct :email ");
                validatReturn = false;
            }
            if (!Regex.IsMatch(user.city, addPattern))
            {
                Console.WriteLine("Pleas Enter Correct :city ");
                validatReturn = false;
            }
            if (!Regex.IsMatch(user.state, addPattern))
            {
                Console.WriteLine("Pleas Enter Correct :state ");
                validatReturn = false;
            }
            if (!Regex.IsMatch(user.zipCode, addPattern))
            {
                Console.WriteLine("Pleas Enter Correct :zipCode ");
                validatReturn = false;
            }
            return validatReturn;
        }

        //find user by full name --Completed
        public static bool showDatils(string enteredName)
        {
            string searchPattern = $"Name     :{enteredName}";
            using (FileStream sf = new FileStream(@"D:\My_Address_Book\AddressBookData.txt", FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(sf))
                {   
                    string line = "";
                    while (( line = sr.ReadLine()) != null)  //reade line and store in line variable if line is not null the retun TRUE
                    {
                        if (line.Equals(searchPattern))
                        {
                            Console.WriteLine(line);
                            for (int i = 1; i < 6; i++)
                            {
                                Console.WriteLine(sr.ReadLine());
                            }
                            return true;
                        }
                    }
                }
            }
            Console.WriteLine("User Not found.."); 
            return false;
        } 

        //edite user datils
        public static void editDatils(string name)
        {
            foreach (User i in usersList)
            {
                if (i.name==name)
                {
                    try
                    {
                        Console.WriteLine("Enter Name  :");
                        i.name = Console.ReadLine();
                        Console.WriteLine("Enter Contact No.:");
                        i.contact = Console.ReadLine();
                        Console.WriteLine("Enter Email  :");
                        i.email = Console.ReadLine();
                        Console.WriteLine("Enter City  :");
                        i.city = Console.ReadLine();
                        Console.WriteLine("Enter state  :");
                        i.state = Console.ReadLine();
                        Console.WriteLine("Enter ZipCode  :");
                        i.zipCode = Console.ReadLine();


                    }
                    catch(Exception e) { Console.WriteLine(e.Message); }
                    break;

                }
            }

        }
       
    }
}

