using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Address_Book_System
{
    public class AddContact
    {

        Address_Book_Model abm = new Address_Book_Model();
        List<Address_Book_Model> contact = new List<Address_Book_Model>();
        Dictionary<string, List<Address_Book_Model>> contactMapping = new Dictionary<string, List<Address_Book_Model>>();

        public void AddContacts()
        {
             abm = new Address_Book_Model();
            Console.WriteLine("Enter Your First name: ");
             tryingWithDifferentName://goto label if name is not match ask again.
            abm.f_name = Console.ReadLine();
            foreach (KeyValuePair<string, List<Address_Book_Model>> kvp in contactMapping)//UC6-Won't allow duplicate first name to be stored in AddressBook .
            {
                if (kvp.Key.Equals(abm.f_name))
                {
                    Console.WriteLine("The Name is already Exist,Try with some other name.");
                    Console.WriteLine("Please try again :");
                    goto tryingWithDifferentName;
                }
            }
            Console.WriteLine("Enter Your Last name");
            abm.l_name = Console.ReadLine();
            Console.WriteLine("Address: ");
            Console.WriteLine("Enter City: ");
            abm.city = Console.ReadLine();
            Console.WriteLine("Enter State: ");
            abm.state = Console.ReadLine();
            Console.WriteLine("Enter your zip Number: ");
            abm.zip = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter your phone Number: ");
            abm.phone = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter Youe Email Id ");
            abm.email = Console.ReadLine();
            contact.Add(abm);
            contactMapping.Add(abm.f_name, contact);
        }
        public void ShowContact()
        {
            if (contact.Count == 0)
            {
                Console.WriteLine("Your Address book is empty. Press any key to continue");
                Console.ReadKey();
                return;
            }
            else
            {
                foreach (var abm in contact)
                {
                    Console.WriteLine("Name: \t" + abm.f_name + " " + abm.l_name);

                    Console.WriteLine("Address: " + abm.city + ", " + abm.state + ", " + abm.zip);

                    Console.WriteLine("Phone No: " + abm.phone);
                    Console.WriteLine("Email: " + abm.email);
                }

            }
            
        }
        public void UpdateContact()
        {
            findingContactAgain://goto statement label
            Console.WriteLine("Enter Your First name: ");
            string user_fname = Console.ReadLine();
            Console.WriteLine("Enter Your Last name");
            string user_lname = Console.ReadLine();
            foreach (var abm in contact)
            {
                if (user_fname.Equals(abm.f_name) && user_lname.Equals(abm.l_name))//Edit will done if contact is present prev.
                {
                EditingAgain:
                    Console.WriteLine("Please select option: "
                          + "1 For First Name,"
                          + "2 For Last Name"
                          + "3 For City "
                          + "4 For State"
                          + "5 For Zip"
                          + "6 For Phone No"
                          + "7 For Email"
                          );

                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Enter Your First name: ");
                            abm.f_name = Console.ReadLine();
                            break;
                        case 2:
                            Console.WriteLine("Enter Your Last name: ");
                            abm.l_name = Console.ReadLine();
                            break;
                        case 3:
                            Console.WriteLine("Enter City: ");
                            abm.city = Console.ReadLine();
                            break;
                        case 4:
                            Console.WriteLine("Enter State: ");
                            abm.state = Console.ReadLine();
                            break;
                        case 5:
                            Console.WriteLine("Enter zip:  ");
                            abm.zip = Convert.ToInt32(Console.ReadLine());
                            break;
                        case 6:
                            Console.WriteLine("Enter Phone No: ");
                            abm.phone = Convert.ToInt32(Console.ReadLine());
                            break;
                        case 7:
                            Console.WriteLine("Enter Email:  ");
                            abm.email = Console.ReadLine();
                            break;
                        Default:
                            Console.WriteLine("Invalid Input!");
                            Console.WriteLine("Do you want to More Editing?");
                            if (Console.ReadKey().Key == ConsoleKey.Y)
                            {
                                goto findingContactAgain;
                            }
                            break;
                    }
                    Console.WriteLine("Do you want to any More changes in the same Contact Y/N ?");
                    if (Console.ReadKey().Key == ConsoleKey.Y)
                    {
                        goto EditingAgain;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Contact could not be Found.Do you Want to Try again?");
                    if (Console.ReadKey().Key == ConsoleKey.Y)
                    {
                        goto findingContactAgain;
                    }
                    return;

                }
            }

        }
        public void RemoveContact()     //code for delete the contact
        {
            Console.WriteLine("Enter the First Name: ");
            string UserInputfirstName = Console.ReadLine();
            Console.WriteLine("Enter the Last Name : ");
            string UserInputlastName = Console.ReadLine();
            foreach (var abm in contact)
            {
                if (abm.f_name.Equals(UserInputfirstName) && abm.l_name.Equals(UserInputlastName))
                {
                    Console.WriteLine("Do You Want To remove this Contact from Your address book? Press(Y/N)");
                    if (Console.ReadKey().Key == ConsoleKey.Y)
                    {
                        contact.Remove(abm);
                        Console.WriteLine("Contact is Removed Press any key To Continue.\n");
                        Console.ReadKey();
                        return;
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("The Contact could not found in Address Book.Pres any key to continue to try again");
                    Console.ReadKey();
                    return;
                }
            }

        }
    }
}


