using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {

                Console.WriteLine("Want to create user ? y/n:");
                char ch = Convert.ToChar(Console.ReadLine());
                if (ch.Equals('y'))
                {
                    Operations obj = new Operations();
                    obj.Add();
                    Console.WriteLine();
                    obj.ShowDatils();
                }
                else { break;}


            }

        }
    }
}
