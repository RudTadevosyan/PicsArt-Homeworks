using System;

namespace PhoneBookApp
{
    class Program
    {
        public class PhoneBookInfos
        {
            public string Name;
            public string PhoneNumber;
            public string Email;

            public PhoneBookInfos(string name, string phoneNumber, string email)
            {
                Name = name;
                PhoneNumber = phoneNumber;
                Email = email;
            }

            public void DisplayInfo()
            {
                Console.WriteLine($"Name: {Name}\nPhone number: {PhoneNumber}\nEmail: {Email}\n");
            }
        }

        static void Main(string[] args)
        {
            PhoneBookInfos[] phoneBook = new PhoneBookInfos[3];

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Enter details for person {i + 1}:");

                string? name;
                do
                {
                    Console.Write("Name: ");
                    name = Console.ReadLine();
                } while (string.IsNullOrWhiteSpace(name));

                string? phoneNumber;
                do
                {
                    Console.Write("Phone number: ");
                    phoneNumber = Console.ReadLine();
                } while (string.IsNullOrWhiteSpace(phoneNumber));

                string? email;
                do
                {
                    Console.Write("Email: ");
                    email = Console.ReadLine();
                } while (string.IsNullOrWhiteSpace(email));

                phoneBook[i] = new PhoneBookInfos(name, phoneNumber, email);
                Console.WriteLine();
            }

            Console.Write("Input a name to search info: ");
            string? searchName = Console.ReadLine();

            int flagFound = 0;

            for(int i = 0; i < phoneBook.Length; i++)
            {
                if(searchName == phoneBook[i].Name)
                {
                    phoneBook[i].DisplayInfo();
                    flagFound = 1;
                }
                
            }

            if(flagFound == 0)
            {
                Console.WriteLine("Not found");
            }


        }
    }
}
