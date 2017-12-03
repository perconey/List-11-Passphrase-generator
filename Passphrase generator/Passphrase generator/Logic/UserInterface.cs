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

        public int Choice { get => _choice; set => _choice = value; }

        public void Start()
        {
            Console.WriteLine();
            showMenu();
            optionChosenAction();
            askForPasswordLenght();


        }
        private void showMenu()
        {
            int consoleInput;
            Console.WriteLine("Welcome to password generator by Perki, you have following password types to choose:\n" +
                "1. Number only\n" +
                "CHOOSE ONE BY TYPING A NUMBER");
            while (!int.TryParse(Console.ReadLine(), out consoleInput))
                Console.Write("The value must be of integer type, try again: ");
            Choice = consoleInput;
        }
        private void optionChosenAction()
        {
            string currentlyWorkingOn = Enum.GetName(typeof(PasswordTypes), Choice);
            switch (Choice)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine($"Your choice is: {currentlyWorkingOn}");

                    break;
            }
        }

        private void askForPasswordLenght()
        {
            int consoleInput;
            Console.WriteLine("How long do you want your password to be?");
            Console.WriteLine("Type number of characters below:");
            while (!int.TryParse(Console.ReadLine(), out consoleInput))
                Console.Write("The value must be of integer type, try again: ");
            passwordLenght = consoleInput;

            if(passwordLenght <= 0 || passwordLenght >= 30)
            {
                Console.WriteLine("Your password lenght is too short/long, setting to 7");
                passwordLenght = 7;
            }
        }
    }
}
