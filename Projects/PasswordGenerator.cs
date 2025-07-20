using System;

namespace PasswordGenerator
{
    class Program
    {
        static char[][] availableCharacters = new char[][]
        {
            new char[]
            {
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U',
                'V', 'W', 'X', 'Y', 'Z'
            },
            new char[]
            {
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u',
                'v', 'w', 'x', 'y', 'z'
            },
            new char[]
            {
                '0','1','2','3','4','5','6','7','8','9'
            },
            new char[]
            {
                '!','@','#','$','%','&','-','_','|','.','?','/'
            }
        };

        static void Main(string[] args)
        {

        char[] password = new char[8]; 
        Random randomNumber = new Random();

        while(true)
        {
            Console.Write("Input 'p' for password genertion, 'x' for exit: ");
            char input = Console.ReadKey().KeyChar;
            Console.WriteLine();

            if(input != 0){
                switch(input)
                {
                    case 'p':
                        int specialCharacters = 4;
                        int passwordLength = 8;

                        for(int i = 0; i < specialCharacters; i++)
                        {
                            int randomIndex = randomNumber.Next(0, availableCharacters[i].Length); 
                            password[i] = availableCharacters[i][randomIndex];
                        }

                        for(int i = 4; i < passwordLength; i++)
                        {
                            int choice = randomNumber.Next(0, 4);
                            int randomIndex = randomNumber.Next(0, availableCharacters[choice].Length);

                            password[i] = availableCharacters[choice][randomIndex];
                        }

                        for(int i = 0; i < passwordLength; i++)
                        {
                            int randomIndex = randomNumber.Next(i, passwordLength);
                            
                            char temp = password[i];
                            password[i] = password[randomIndex];
                            password[randomIndex] = temp;
                        }

                        string newPassword = new string(password);
                        Console.WriteLine($"Generated password: {newPassword}");

                        break;

                    case 'x':
                        return;
                    default:
                        Console.WriteLine("Invalid Input!");
                        break;
                }
            }
            else{
                Console.WriteLine("Input can't be empty!");
            }
        }



        }  
    }
}
