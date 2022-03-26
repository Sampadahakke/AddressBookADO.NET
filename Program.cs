using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookADO.NET
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--------------------------Welcome-----------------------");
            AddressbookRepo repo = new AddressbookRepo();
            AddressbookModel model = new AddressbookModel();
            model.FirstName = "Sampada";
            model.LastName = "Hakke";
            model.Address = "Sangli";
            model.City = "Sangli";
            model.State = "Maharashtra";
            model.Zip = 416416;
            model.PhoneNumber = 8421729091;
            model.BookName = "ABC";
            model.Type = "Friends";
            if (repo.AddContacts(model))
            {
                Console.WriteLine("Contact Added Successfully");
            }
            else
            {
                Console.WriteLine("Failed...");
            }
            repo.GetContacts();
            Console.ReadLine();
        }
    }
}
