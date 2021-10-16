using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;

namespace MultiThreadedBook
{
    class Program
    {
        private static string filename { get; set; }

        static void CountOfWords(List<string> words)
        {
            words = words.ConvertAll(d => d.ToLower());

            Console.WriteLine($"The count of words is {words.Count()}");
        }

        static void ShortestWord(List<string> words)
        {
            var sortedList = words.OrderBy(x => x.Length);

            Console.WriteLine($"The shortest word is: {sortedList.FirstOrDefault()}");
        }

        static void LongestWord(List<string> words)
        {
            var sortedList = words.OrderBy(x => x.Length);

            Console.WriteLine($"The longest words is: {sortedList.LastOrDefault()}");
        }

        static void AverageWordLenght(List<string> words)
        {          
            int sumOfChars = 0;

            foreach (var word in words) sumOfChars += word.Length;

            Console.WriteLine($"The average word length is: {sumOfChars / words.Count()}");
        }

        static void FiveMostCommonWords(List<string> words)
        {
            List<string> FiveMostCommonWords = new List<string>();
            FiveMostCommonWords = words.GroupBy(x => x)
                .OrderByDescending(x => x.Count())
                .Select(x => x.Key)
                .Take(5)
                .ToList();

            Console.WriteLine($"The five most common words are: {String.Join(", ", FiveMostCommonWords)}");
        }

        static void FiveLeastCommonWords(List<string> words)
        {
            List<string> FiveLeastCommonWods = new List<string>();
            FiveLeastCommonWods = words.GroupBy(x => x)
                .OrderBy(x => x.Count())
                .Select(x => x.Key)
                .Take(5)
                .ToList();

            Console.WriteLine($"The five least common words are: {String.Join(", ", FiveLeastCommonWods)}");
        }

        static void Main(string[] args)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            filename = @"Book.txt";
            List<string> words = new List<string>();
            char[] delims = { '.', '!', '?', ',', '(', ')', '\t', '\n', '\r', ' ' };

            using (var reader = new StreamReader(filename))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    words.AddRange(line.Split(delims, StringSplitOptions.RemoveEmptyEntries));
                }
            }

            words = words.ConvertAll(d => d.ToLower());

            Thread[] threads = new Thread[6];
            threads[0] = new Thread(() => CountOfWords(words));
            threads[1] = new Thread(() => ShortestWord(words));
            threads[2] = new Thread(() => LongestWord(words));
            threads[3] = new Thread(() => AverageWordLenght(words));
            threads[4] = new Thread(() => FiveMostCommonWords(words));
            threads[5] = new Thread(() => FiveLeastCommonWords(words));

            for (int i = 0; i < threads.Count(); i++)
            {
                threads[i].Start();
            }

            for (int i = 0; i < threads.Count(); i++)
            {
                threads[i].Join();
            }

            watch.Stop();
            Console.WriteLine($"Elapsed time = {watch.ElapsedMilliseconds} milliseconds");
        }
    }
}
