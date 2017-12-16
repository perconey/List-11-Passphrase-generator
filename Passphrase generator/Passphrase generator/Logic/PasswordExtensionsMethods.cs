using System;
using System.Collections.Generic;

namespace Passphrase_generator.Logic
{
    public static class PasswordExtensionsMethods
    {
        //lower case letters 97 - 122
        //numbers 48 - 57
        //upper case letters 65 - 90
        public static List<String> AllPwToUpper(this List<String> value)
        {
            var tl = new List<String>();
            if(value != null)
            {
                foreach(var el in value)
                {
                    tl.Add(el.ToUpper());
                }
                return tl;
            }
            return value;
        }

    }
}
