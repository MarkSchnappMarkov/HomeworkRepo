using System;
using System.Linq;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;

namespace BookHomework
{
    class Program
    {
        static int CountOfWords(List<string> words)
        {
            return words.Count();
        }

        static string ShortestWord(List<string> words)
        {
            var sortedList = words.OrderBy(x => x.Length);

            return sortedList.FirstOrDefault();
        }

        static string LongestWord(List<string> words)
        {
            var sortedList = words.OrderBy(x => x.Length);

            return sortedList.LastOrDefault();
        }

        static int AverageWordLenght(List<string> words)
        {
            int sumOfChars = 0;

            foreach (var word in words)
            {
                sumOfChars += word.Length;
            }

            return sumOfChars / words.Count();
        }

        static void Main(string[] args)
        {
            #region WordsToList

            string filename = @"Book.txt";
            var words = new List<string>();
            char[] delims = { '.', '!', '?', ',', '(', ')', '\t', '\n', '\r', ' ' };

            using (var reader = new StreamReader(filename))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    words.AddRange(line.Split(delims, StringSplitOptions.RemoveEmptyEntries));
                }
            }

            #endregion

            #region WordsToLowerCase

            words = words.ConvertAll(d => d.ToLower());

            #endregion

            #region RemoveRepetitions

            words = words.Distinct().ToList();

            #endregion

            /*
            foreach (var word in words)
            {                
                Console.WriteLine(word);
            }
            */

            Console.WriteLine("Count of words is: " + CountOfWords(words));
            Console.WriteLine("The shortest word is: " + ShortestWord(words));
            Console.WriteLine("The longest word is: " + LongestWord(words));
            Console.WriteLine("Average word length is: " + AverageWordLenght(words));
        }
    }
}
