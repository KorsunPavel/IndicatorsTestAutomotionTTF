using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestIndicatorsAutomation
{
    public static class TTFPostCreator
    {
        public static string CreatPost(out string PreviousBody)
        {
            PreviousTitle = WordGenerator();
            PreviousBody = WordGenerator();
            return PreviousTitle;
        }

        public static string PreviousTitle
        {
            get; set;
        }
        public static string PreviousBody
        {
            get; set;
        }

        static string[] article = { "A", "B", "C", "D", "E", };
        static string[] noun = { "g", "w", "x", "l", "r", };

        static Random rndarticle = new Random();
        static Random rndnoun = new Random();
        //
        static string newWord;
        static string WordGenerator()
        {
            
            for (int i = 0; i < 3; i++)
            {
                int randomarticle = (int)rndarticle.Next(article.Length);
                int randomnoun = rndnoun.Next(noun.Length);
                newWord += article[randomarticle] + noun[randomnoun];
            }
            return newWord;
        }
    }
}