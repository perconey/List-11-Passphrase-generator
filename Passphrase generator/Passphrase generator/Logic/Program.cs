using Passphrase_generator.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Passphrase_generator.DatabaseFetchLogic;

namespace Passphrase_generator
{
    class Program
    {
        static void Main(string[] args)
        {
            DatabaseFetch f = new DatabaseFetch();

            UserInterface gui = new UserInterface();

            gui.Start();
            Console.ReadLine();
        }
    }
}
