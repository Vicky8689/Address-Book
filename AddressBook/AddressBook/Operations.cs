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
       private string contact,firstName,lastName,name,email,city,state,zipCode;
        //patterns
       public string namePattern = @"^[A-Z]{1}[A-Za-z]{2,}$";
       public string addPattern = @"^[\w]{4,}$";
       public string zipCodePattern = @"^[0-9]{6}$";
       public string contactPattern = @"^(0|\+91)?[789]\d{9}$";
       public string emailPattern = @"^[\w\.-]+@[\w]+\.[a-zA-Z]{2,}$";

        
        public override void Add()
        {

            Console.Write("Enter your number :");
            contact = Console.ReadLine();
            //checking user is present or not
            foreach(User i in usersList)
            {
                if (i.contact.Equals(contact))
                {
                    Console.WriteLine("User already exite please try again..");
                    return; 
                }
            }

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
            //add user datils by get
            user.contact = contact;
            user.name = name;
            user.email = email;
            user.city = city;
            user.zipCode = zipCode;
            user.state = state;
            //add user in list

            usersList.Add(user);
            Bookdata.AddDataTotxt(usersList);
        }
        
        //show user datiles 
        public static void showDatils()
        {
            if(usersList.Count()==0) 
            {
                Console.WriteLine("Empty AddressBook");
                return;
            }
            Console.WriteLine("---------------------ALL CONTACTS---------------------------------");
            foreach (User i in  usersList) 
            {
                Console.WriteLine("Name        :" + i.name);
                Console.WriteLine("Contact No. :" + i.contact);
                Console.WriteLine("Email       :" + i.email);
                Console.WriteLine("City        :" + i.city);
                Console.WriteLine("state       :" + i.state);
                Console.WriteLine("ZipCode     :" + i.zipCode);
                Console.WriteLine("------------------------------------------------------------------");
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
        //find user by full name 
       // public static void searchUser(string enteredName)
        public static bool showDatils(string enteredName)
        {

            //foreach (User i in usersList)
            //{

            //    //if (i.name.Equals(enteredName))
            //    //{



            //    //    //Console.WriteLine("Name        :" + i.name);
            //    //    //Console.WriteLine("Contact No. :" + i.contact);
            //    //    //Console.WriteLine("Email       :" + i.email);
            //    //    //Console.WriteLine("City        :" + i.city);
            //    //    //Console.WriteLine("state       :" + i.state);
            //    //    //Console.WriteLine("ZipCode     :" + i.zipCode);
            //    //    return true;

            //    //}
            //}
            string searchPattern = $"Name     :{enteredName}";
            
            using (FileStream sf = new FileStream(@"D:\My_Address_Book\AddressBookData.txt", FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(sf))
                {
                    
                        if (sr.ReadLine().Equals(searchPattern))
                        {
                        
                        for(int i = 1; i < 6; i++)
                        {
                            Console.WriteLine(sr.ReadLine());
                        }
                        return true;
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

