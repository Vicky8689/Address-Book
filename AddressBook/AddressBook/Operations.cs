using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AddressBook
{
    
    abstract class methods
    {
        public abstract void Add();

    }
    internal class Operations: methods     //Inherit Abstract class methods
    {
      // public static List<User> usersList = new List<User>();
      private string firstName,lastName;
        //patterns
       public string namePattern = @"^[A-Z]{1}[A-Za-z]{2,}$";
       //public string addPattern = @"^[\w]{4,}$";
       //public string zipCodePattern = @"^[0-9]{6}$";
       //public string contactPattern = @"^(0|\+91)?[789]\d{9}$";
       //public string emailPattern = @"^[\w\.-]+@[\w]+\.[a-zA-Z]{2,}$";
       // public string namePattern = @"^[\w]{4,}$";
        public string addPattern = @"^[\w]{4,}$";
        public string zipCodePattern = @"^[\w]{4,}$";
        public string contactPattern = @"^[\w]{4,}$";
        public string emailPattern = @"^[\w]{4,}$";


        public override void Add()
        {

            User user = new User();
            Console.Write("Enter your number :");
            user.Contact = Console.ReadLine();

            //checking user is present or not
            string path = @"D:\My_Address_Book\AddressBookData.json";
            string json = File.ReadAllText(path);
            json = "[" + json + "]";
            var usersFile = JsonConvert.DeserializeObject<List<User>>(json);
          
            foreach (var i in usersFile)
            {
                if (i.Contact.Equals(user.Contact)) {
                    Console.WriteLine("User already exists");
                    return; }                
            }       
            Console.Write("Enter your firstname :");
            firstName = Console.ReadLine();

            Console.Write("Enter your lastname :");
            lastName = Console.ReadLine();

            user.Name = firstName + " " + lastName;

            Console.Write("Enter your email :");
            user.Email = Console.ReadLine();

            Console.Write("Enter your city :");
            user.City = Console.ReadLine();

            Console.Write("Enter your state :");
            user.State = Console.ReadLine();

            Console.Write("Enter your Zip Code:");
            user.ZipCode = Console.ReadLine();

            //checking validation
            if(!validattion(user)) { return; }
            //add user in list

          
            
            Bookdata.AddData(user);
        }
        
        //show user datiles  --complited
        public static void showDatils()
        {
            string path = @"D:\My_Address_Book\AddressBookData.json";
            string json = File.ReadAllText(path);
            json = "[" + json + "]";
            var users = JsonConvert.DeserializeObject<List<User>>(json);
           // Console.WriteLine(users);

            foreach (var user in users)
            {
                Console.WriteLine("Name    :" + user.Name);
                Console.WriteLine("Contact :" + user.Contact);
                Console.WriteLine("Email   :" + user.Email);
                Console.WriteLine("City    :" + user.City);
                Console.WriteLine("State   :" + user.State);
                Console.WriteLine("Zipcode :" + user.ZipCode);
                Console.WriteLine();

            }
        }

        //validation    --Completed
        public bool validattion(User user)
        {
            bool validatReturn = true;

            if (!Regex.IsMatch(user.Contact, contactPattern))
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
            if (!Regex.IsMatch(user.Email, emailPattern))
            {
                Console.WriteLine("Pleas Enter Correct :email ");
                validatReturn = false;
            }
            if (!Regex.IsMatch(user.City, addPattern))
            {
                Console.WriteLine("Pleas Enter Correct :city ");
                validatReturn = false;
            }
            if (!Regex.IsMatch(user.State, addPattern))
            {
                Console.WriteLine("Pleas Enter Correct :state ");
                validatReturn = false;
            }
            if (!Regex.IsMatch(user.ZipCode, addPattern))
            {
                Console.WriteLine("Pleas Enter Correct :zipCode ");
                validatReturn = false;
            }
            return validatReturn;
        }

        //find user by full name --Completed
        public static bool showDatils(string enteredName)
        {


            string path = @"D:\My_Address_Book\AddressBookData.json";
            string json = File.ReadAllText(path);
            json = "[" + json + "]";
            var users = JsonConvert.DeserializeObject<List<User>>(json);
            // Console.WriteLine(users);

            foreach (var user in users)
            {

                if (user.Name == enteredName)
                {


                    Console.WriteLine("Name    :"+user.Name);
                    Console.WriteLine("Contact :"+user.Contact);
                    Console.WriteLine("Email   :"+user.Email);
                    Console.WriteLine("City    :"+user.City);
                    Console.WriteLine("State   :"+user.State);
                    Console.WriteLine("Zipcode :"+user.ZipCode);
                    Console.WriteLine();
                    return true;
                }

            }
                return false;
        } 

        //edite user datils
        public static void editDatils(string name)
        {
            string path = @"D:\My_Address_Book\AddressBookData.json";
            string json = File.ReadAllText(path);
            json = "[" + json + "]";

            List<User> users = JsonConvert.DeserializeObject<List<User>>(json);
            foreach (User user in users)
            {
                if (user.Name == name)
                {                  
                    Console.WriteLine("Enter Name  :");
                    user.Name= Console.ReadLine();
                    Console.WriteLine("Enter Contact No.:");
                    user.Contact = Console.ReadLine();
                    Console.WriteLine("Enter Email  :");
                    user.Email = Console.ReadLine();
                    Console.WriteLine("Enter City  :");
                    user.City = Console.ReadLine();
                    Console.WriteLine("Enter state  :");
                    user.State = Console.ReadLine();
                    Console.WriteLine("Enter ZipCode  :");
                    user.ZipCode = Console.ReadLine();                  
                    Console.WriteLine();                   
                }
            }
            string updatedJson = JsonConvert.SerializeObject(users, Formatting.Indented);
            
            string letest = updatedJson.Substring(1, updatedJson.Length - 2);
            File.WriteAllText(path, letest);
            Console.WriteLine("file update ");
        }
       
    }
}

