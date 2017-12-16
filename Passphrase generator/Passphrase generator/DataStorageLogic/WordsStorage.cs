using PassphraseGenerator.DataModel;
using System;
using System.Collections.Generic;

namespace PassphraseGenerator.DataStorageLogic
{
    static class WordsStorage
    {
        private static List<String> _words = new List<string>();

        public static List<string> Words { get => _words; set => _words = value; }

        static WordsStorage()
        {
            var db =  new passgenmContext();
            foreach(var item in db.Words)
            {
                Words.Add(item.word);
            }
        }
    }
}
