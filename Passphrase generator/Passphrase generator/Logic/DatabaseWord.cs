using PassphraseGenerator.DataStorageLogic;
using System;
using System.Linq;

namespace PassphraseGenerator.Logic
{
    public class DatabaseWord
    {
        public string Word { get; set; }

        public DatabaseWord(int desiredLenght)
        {
            var query =  from item in WordsStorage.Words
                         where item.Length == desiredLenght
                         select item;
            try
            {
                 Word = query.First();
            }catch(Exception ex)
            {
                 Word = "therewerenosuchalongword";
            };
        }

        public override string ToString()
        {
            return Word;
        }
    }
}
