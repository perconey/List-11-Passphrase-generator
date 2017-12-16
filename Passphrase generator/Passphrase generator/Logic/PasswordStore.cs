using System;
using System.Collections.Generic;

namespace Passphrase_generator.Logic
{
    static class PasswordStore
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
