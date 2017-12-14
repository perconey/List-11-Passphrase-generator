using Passphrase_generator.Logic;
using PassphraseGenerator.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
