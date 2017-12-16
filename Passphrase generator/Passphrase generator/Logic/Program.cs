using Passphrase_generator.Logic;
using System;

namespace Passphrase_generator
{
    class Program
    {
        static void Main(string[] args)
        {

            UserInterface gui = new UserInterface();

            gui.Start();
            Console.ReadLine();
        }
    }
}
