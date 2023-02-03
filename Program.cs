using System.Numerics;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace Address_Book_System
{
    public class Program
    {
       //static string f_name, l_name, city, state, zip, phone, email;
        public static void Main(String[] args)
        {
            Console.WriteLine("Welcome to AddressBook");
            AddContact ac = new AddContact();
            //ac.AddContacts();
            //ac.ShowContact();
            ReEnteringApp:
            Console.WriteLine("Select 1 for Create new Contact, \n" +
                "Select 2 for Edit Contact, \n" +
                "Select 3 for Print Contact, \n" +
                "Select 4 for Delete Existing Contact.");
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    ac.AddContacts();
                    break;
                case 2:
                    ac.UpdateContact();
                    break;
                case 3:
                    ac.ShowContact();
                    break;
                case 4:
                    ac.RemoveContact();
                    break;
                default:
                    Console.WriteLine("Invalid option Selected , Please try again");

                    break;
            }
            goto ReEnteringApp; 
            
        }
       

    }
}