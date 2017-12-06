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
        private char uppercase;


        public int Choice { get => _choice; set => _choice = value; }

        public void Start()
        {
            Console.WriteLine();
            showMenu();
            optionChosenAction();
            askForPasswordLenght();
            generate();

        }

        private void generate()
        {
            Password pass = new Password(Choice, passwordLenght, uppercase);
        }

        private void showMenu()
        {
            int consoleInput;
            Console.WriteLine("Welcome to password generator by Perki, you have following password types to choose:\n" +
                "1. Number only\n" +
                "2. Characters and numbers combined\n" +
                "CHOOSE ONE BY TYPING A NUMBER");
            while (!int.TryParse(Console.ReadLine(), out consoleInput))
                Console.Write("The value must be of integer type, try again: ");
            Choice = consoleInput;

            if(Choice == 2)
            {
                SubMenu();
            }
        }

        private void SubMenu()
        {
            Console.Clear();
            char consoleInput;
            Console.WriteLine("You have chosen option 2, now maintain settings listed below:\n" +
                "Do you want your passphrases to be entirely UPPERCASE?\n" +
                "Choose one (y/n)");
            consoleInput = Console.ReadKey().KeyChar;

            if(consoleInput != 'y' || consoleInput != 'n')
            {
                Console.WriteLine("You haven't provided the right character nor y ,n: SETTING TO -> No");
                consoleInput = 'n';
            }

            uppercase = consoleInput;
        }
        private void optionChosenAction()
        {
            string currentlyWorkingOn = Enum.GetName(typeof(PasswordTypes), Choice);

            Console.Clear();
            Console.WriteLine($"Your choice is: {currentlyWorkingOn}");

        }

        private void askForPasswordLenght()
        {
            int consoleInput;
            Console.WriteLine("How long do you want your password to be?");
            Console.WriteLine("Type number of characters below:");
            while (!int.TryParse(Console.ReadLine(), out consoleInput))
                Console.Write("The value must be of integer type, try again: ");
            passwordLenght = consoleInput;

            if(passwordLenght <= 0 || passwordLenght > 30)
            {
                Console.WriteLine("Your password lenght is too short/long, setting to 30");
                passwordLenght = 30;
            }
        }
    }
}
