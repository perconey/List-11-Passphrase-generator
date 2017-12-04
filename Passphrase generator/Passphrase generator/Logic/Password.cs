using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passphrase_generator.Logic
{
    class Password
    {
        private string _passwordFinal;
        public string PasswordFinal{ set=> _passwordFinal = value; get=> _passwordFinal; }
        public StringBuilder Str { get => _str; set => _str = value; }

        private StringBuilder _str = new StringBuilder();

        private static readonly Random getrandom = new Random();
        private static readonly object syncLock = new object();
        public static int GetRandomNumber(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                return getrandom.Next(min, max);
            }
        }


        public Password(int type, int len)
        {
            switch(type)
            {
                case 1:
                    while(len > 0)
                    {
                        Str.Append(GetRandomNumber(0, 9).ToString());
                        len--;
                    }
                    Console.WriteLine(Str);
                    break;
            }
        }
    }
}
