using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passphrase_generator.Logic
{
    class UserInterface
    {
        public enum PasswordTypes
        {
            NumberOnly = 1
        };
        private int _choice;
        private int passwordLenght;

        // 0 - upperCase 
        private char[] settings = new char[1];


        public int Choice { get => _choice; set => _choice = value; }

        public void Start()
        {
            do
            {

                Console.WriteLine();
                showMenu();
                CurrentlyWorkingOnStringRecognize();
                askForPasswordLenght();
                generate();

            } while (true);

        }

        /// <summary>
        /// Generates password for current properties
        /// </summary>
        private void generate()
        {
            Password pass = new Password(Choice, passwordLenght, settings);
        }

        /// <summary>
        /// Shows menu and sets choice to user choice from console input
        /// </summary>
        private void showMenu()
        {
            int consoleInput;
            Console.WriteLine("Welcome to password generator by Perki, you have following password types to choose:\n" +
                "1. Number only\n" +
                "2. Characters and numbers combined\n" +
                "3. Characters only\n" +
                "9. Database settings\n" +
                "CHOOSE ONE BY TYPING A NUMBER");
            while (!int.TryParse(Console.ReadLine(), out consoleInput))
                Console.Write("The value must be of integer type, try again: ");
            Choice = consoleInput;

            if(Choice == 2 || Choice == 3)
            {
                SubMenu();
            }
            if(Choice == 9)
            {
                DatabaseSettings();
            }
        }

        private void DatabaseSettings()
        {
            do
            {
                Console.Clear();
                char consoleInput;
                Console.WriteLine("Choose desired number to make changes to entrie password database:\n" +
                    "1. Make entire database UPPERCASE\n" +
                    "9. Show all stored passwords\n" +
                    "Press e to exit");
                consoleInput = Console.ReadKey().KeyChar;

                switch (consoleInput)
                {
                    case '1':
                        PasswordStore.Passwords = PasswordStore.Passwords.AllPwToUpper();
                        Console.WriteLine("Cool and good");
                        break;
                    case '9':
                        Console.WriteLine();
                        PasswordStore.ShowPasswords();

                        break;
                    case 'e':
                        Console.Clear();
                        Start();
                        break;
                    default:
                        Console.WriteLine("What do you mean?");
                        break;
                }
            } while (true);
        }
        /// <summary>
        /// Submenu for choice 2 -> letters&numbers
        /// </summary>
        private void SubMenu()
        {
            Console.Clear();
            char consoleInput;
            Console.WriteLine("You have chosen option with characters, now maintain settings listed below:\n" +
                "Do you want your passphrases to be entirely UPPERCASE?\n" +
                "Choose one (y/n)");
            consoleInput = Console.ReadKey().KeyChar;

            if(consoleInput != 'y' || consoleInput != 'n')
            {
                Console.WriteLine("You haven't provided the right character nor y ,n: SETTING TO -> No");
                consoleInput = 'n';
            }

            settings[0] = consoleInput;
        }

        /// <summary>
        /// Recognizes on which type of password, are you working on
        /// </summary>
        private void CurrentlyWorkingOnStringRecognize()
        {
            string currentlyWorkingOn = Enum.GetName(typeof(PasswordTypes), Choice);

            Console.Clear();
            Console.WriteLine($"Your choice is: {currentlyWorkingOn}");

        }
        /// <summary>
        /// Asks user about lenght on next password to be generated and saves in into passwordLenght property
        /// </summary>
        private void askForPasswordLenght()
        {
            int consoleInput;
            Console.WriteLine("How long do you want your password to be?");
            Console.WriteLine("Type number of characters below:");
            while (!int.TryParse(Console.ReadLine(), out consoleInput))
                Console.Write("The value must be of integer type, try again: ");
            passwordLenght = consoleInput;
            Console.Clear();
            if(passwordLenght <= 0 || passwordLenght > 30)
            {
                Console.WriteLine("Your password lenght is too short/long, setting to 30");
                passwordLenght = 30;
            }
        }
    }
}
