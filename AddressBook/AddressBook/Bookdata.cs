using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    internal class Bookdata
    {
       
       public static void AddDataTotxt(List<User> list)
        {
            using (FileStream file = new FileStream(@"D:\My_Address_Book\AddressBookData.txt", FileMode.Append, FileAccess.Write))
            {

                using (StreamWriter writer = new StreamWriter(file, Encoding.UTF8))
                {

                    foreach (User i in list)
                    {
                        Console.WriteLine("***********************************");
                        writer.WriteLine("Name     :"+i.name);
                        writer.WriteLine("Contact  :"+i.contact);
                        writer.WriteLine("Email    :"+i.email);
                        writer.WriteLine("City     :"+i.city);
                        writer.WriteLine("State    :"+i.state);
                        writer.WriteLine("ZipCode  :"+i.zipCode);
                        Console.WriteLine("***********************************");
                    }

                    
                }

            }
        }
    }
}
