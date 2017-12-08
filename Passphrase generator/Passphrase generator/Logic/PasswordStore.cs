using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passphrase_generator.Logic
{
    class PasswordStore
    {
        public static List<string> Passwords = new List<string>();

        public static void ShowPasswords()
        {
            foreach(var el in Passwords)
            {
                Console.WriteLine(el.ToString());
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}
