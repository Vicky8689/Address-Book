using System;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace AddressBook
{
    
    abstract class methods
    {
        public abstract void Add();

    }
    internal class Operations: methods     //Inherit Abstract class methods
    {
     
      private string firstName,lastName;
    
        public static string cs = ConfigurationManager.ConnectionStrings["abcs"].ConnectionString;
      // public string namePattern = @"^[A-Z]{1}[A-Za-z]{2,}$";
       //public string addPattern = @"^[\w]{4,}$";
       //public string zipCodePattern = @"^[0-9]{6}$";
       //public string contactPattern = @"^(0|\+91)?[789]\d{9}$";
       //public string emailPattern = @"^[\w\.-]+@[\w]+\.[a-zA-Z]{2,}$";
       public string namePattern = @"^[\w]{4,}$";
        public string addPattern = @"^[\w]{4,}$";
        public string zipCodePattern = @"^[\w]{4,}$";
        public string contactPattern = @"^[\w]{4,}$";
        public string emailPattern = @"^[\w]{4,}$";
        
        //---------------------add by ado is completed
        public override void Add()
        {

            User user = new User();
            Console.Write("Enter your number :");
            user.Contact = Console.ReadLine();

            //checking user is present or not 
            using (SqlConnection conn = new SqlConnection(cs))
            {
                string qurey_find= $"select count(*) from AddressBookT where contact = '{user.Contact}'";
                SqlCommand cmd = new SqlCommand(qurey_find, conn);
                conn.Open();
               var a  = (int)cmd.ExecuteScalar();            
                if (a>0)
                {
                    Console.WriteLine("user already present ples try again....");
                    return;
                }               
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
            if (!validattion(user)) { return; }


            //adding data
            using (SqlConnection conn = new SqlConnection(cs))
            {
                string qurey_Add = $"insert into AddressBookT values ('{user.Name}','{user.Contact}','{user.Email}','{user.City}','{user.State}','{user.ZipCode}')";
                SqlDataAdapter adapter = new SqlDataAdapter(qurey_Add, conn);

                //create data table 
                DataTable add_book_table = new DataTable();
                //create data set
                DataSet ds = new DataSet();

                ds.Tables.Add(add_book_table);
                adapter.Fill(ds);
                adapter.Update(add_book_table);

            }
         
        }
        
        //---------------------show user datiles(table)  completed
        public static void showDatils()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    string qurey_datils = "select * from AddressBookT";
                    SqlCommand cmd = new SqlCommand(qurey_datils, conn);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Console.WriteLine();
                        Console.WriteLine("name= " + dr["name"] );
                        Console.WriteLine("contact= "+ dr["contact"]);
                        Console.WriteLine("Email= " + dr["email"]);
                        Console.WriteLine("city= "+ dr["city"]);
                        Console.WriteLine("state= " + dr["state"]);
                        Console.WriteLine("zipcode= " + dr["zipcode"]);
                        Console.WriteLine();                          
                    }


                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

        }

        //------------------------validation    Completed
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

        //-----------------------find user by full name Completed
        public static bool showDatils(string Contact)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    string qurey_datils_by = $"select * from AddressBookT where contact = '{Contact}'";
                    SqlCommand cmd = new SqlCommand(qurey_datils_by, conn);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Console.WriteLine();
                        Console.WriteLine("name= " + dr["name"]);
                        Console.WriteLine("contact= " + dr["contact"]);
                        Console.WriteLine("Email= " + dr["email"]);
                        Console.WriteLine("city= " + dr["city"]);
                        Console.WriteLine("state= " + dr["state"]);
                        Console.WriteLine("zipcode= " + dr["zipcode"]);
                        Console.WriteLine();
                        return true;
                        
                    }



                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return false;

        }

        //--------------------edite user datils by contact completed
        public static void editDatils(string Contact)
        {
            User user = new User();
            Console.WriteLine("Enter Name  :");
            user.Name = Console.ReadLine();
           
            Console.WriteLine("Enter Email  :");
            user.Email = Console.ReadLine();
            Console.WriteLine("Enter City  :");
            user.City = Console.ReadLine();
            Console.WriteLine("Enter state  :");
            user.State = Console.ReadLine();
            Console.WriteLine("Enter ZipCode  :");
            user.ZipCode = Console.ReadLine();
            Console.WriteLine();
            try
            {
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    string qurey_datils = $"update AddressBookT set name='{user.Name}' ,email = '{user.Email}',city = '{user.City}',state = '{user.State}',zipcode = '{user.ZipCode}' where contact = '{Contact}'";
                    SqlCommand cmd = new SqlCommand(qurey_datils, conn);
                    conn.Open();
                    int a = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
                           
            }
           

        //----------------------delet data by contact completed
        public static void deleteData(string in_contact) 
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                string qurey_Add = $"delete from AddressBookT where contact = '{in_contact}' ";
                SqlDataAdapter adapter = new SqlDataAdapter(qurey_Add, conn);

                //create data table 
                DataTable add_book_table = new DataTable();
                //create data set
                DataSet ds = new DataSet();

                ds.Tables.Add(add_book_table);
                adapter.Fill(ds);
                adapter.Update(add_book_table);

            }

        }


        }
       
    }


