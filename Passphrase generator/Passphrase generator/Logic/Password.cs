using PassphraseGenerator.Enums;
using PassphraseGenerator.Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Passphrase_generator.Logic
{
    public class Password
    {
        
        private string _passwordFinal;
        public string PasswordFinal{ set=> _passwordFinal = value; get=> _passwordFinal; }
        public StringBuilder Str { get => _str; set => _str = value; }
        public List<int> RandomNumList { get => _randomList; set => _randomList = value; }
        public char[] Settings { get => _settings; set => _settings = value; }

        private StringBuilder _str = new StringBuilder();

        private static readonly Random getrandom = new Random();
        private List<int> _randomList = new List<int>();

        private static readonly object syncLock = new object();
        public static int GetRandomNumber(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                return getrandom.Next(min, max);
            }
        }

        //Settings - Enum "Setting" provides easier settings manipulation
        // settings[0] = 1 user wants to generate all UPPERCASE passwords / 0 -> not
        private char[] _settings = new char[1];


        public Password(int type, int len, char[] set)
        {
            //handle settings
            _settings = set;

            //lower case letters 97 - 122
            //numbers 48 - 57
            Str.Clear();
            switch (type)
            {
                case (int)PasswordType.NumberOnly:
                    while(len > 0)
                    {
                        Str.Append(GetRandomNumber(0, 9).ToString());
                        len--;
                    }
                    PasswordFinal = Str.ToString();
                    break;
                case (int)PasswordType.CharAndNum:
                    while (len > 0)
                    {
                        var random = GetRandomNumber(0, 100);
                        if(random <= 50)
                        {
                            RandomNumList.Add(GetRandomNumber(97, 122));
                        }
                        else
                        {
                            RandomNumList.Add(GetRandomNumber(48, 57));
                        }

                        len--;
                    }
                    foreach(var el in RandomNumList)
                    {
                        Str.Append((char)el);
                    }
                    PasswordFinal = Str.ToString();
                    break;

                case (int)PasswordType.CharOnly:
                    while (len > 0)
                    {

                        RandomNumList.Add(GetRandomNumber(97, 122));

                        len--;
                    }
                    foreach (var el in RandomNumList)
                    {
                        Str.Append((char)el);
                    }
                    PasswordFinal = Str.ToString();
                    break;
                case (int)PasswordType.Word:
                    var dbw = new DatabaseWord(len);
                    PasswordFinal = dbw.Word;
                    break;
                case (int)PasswordType.WordAndNum:
                    if(len <= 6)
                    {
                        for (int i = 0 ; i < len ; i++)
                        {
                            Str.Append(GetRandomNumber(0, 9).ToString());
                        }
                        PasswordFinal = Str.ToString();
                        break;
                    }
                    var wan = new DatabaseWord((len - 4));
                    Str.Append(wan.Word);
                    for(int i = 0; i < 4; i++)
                    {
                        Str.Append(GetRandomNumber(0, 9).ToString());
                    }
                    PasswordFinal = Str.ToString();
                    break;
            }
            ApplySettings();

            PasswordStore.Passwords.Add(PasswordFinal);
        }

        private void ApplySettings()
        {
            if (_settings[(int)SettingsIds.IsUppercase] == 'y')
            {
                PasswordFinal = PasswordFinal.ToUpper();
            }
        }

    }
}
