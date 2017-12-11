
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace ClassLibrary1
{
    public class Class1
    {

        public static void ReadWord()
        {
            var db = new passgenEntities();

            using (var context = new WordsContext())
            {
               foreach(var e in context.Words)
                {
                    System.Console.WriteLine(e);
                }
            }
        }

    }

}
