using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;

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

        static void FiveMostCommonWords(List<string> words)
        {
            List<string> FiveMostCommonWords = new List<string>();
            FiveMostCommonWords = words.GroupBy(x => x)
                .OrderByDescending(x => x.Count())
                .Select(x => x.Key)
                .Take(5)
                .ToList();

            Console.WriteLine(String.Join(", ",FiveMostCommonWords));
        }

        static void FiveLeastCommonWords(List<string> words)
        {
            List<string> FiveLeastCommonWods = new List<string>();
            FiveLeastCommonWods = words.GroupBy(x => x)
                .OrderBy(x => x.Count())
                .Select(x => x.Key)
                .Take(5)
                .ToList();

            Console.WriteLine(String.Join(", ", FiveLeastCommonWods));
        }

        static void Main(string[] args)
        {
            Stopwatch watch = new Stopwatch();

            watch.Start();

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

            #region PrintResults

            Console.WriteLine("Count of words is: " + CountOfWords(words));
            Console.WriteLine("The shortest word is: " + ShortestWord(words));
            Console.WriteLine("The longest word is: " + LongestWord(words));
            Console.WriteLine("Average word length is: " + AverageWordLenght(words));
            FiveMostCommonWords(words);
            FiveLeastCommonWords(words);

            #endregion

            watch.Stop();

            Console.WriteLine($"Elapsed time = {watch.Elapsed}");
        }
    }
}
