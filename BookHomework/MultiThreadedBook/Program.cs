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
        private static string filename = @"Book.txt";

        private static List<Thread> threads { get; set; }

        static void CountOfWords(string filename)
        {
            #region getAndReadText

            List<string> words = new List<string>();
            var threads = new List<Thread>();
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

            #endregion

            Console.WriteLine($"The count of words is {words.Count()}");
        }

        static void ShortestWord(string filename)
        {
            #region getAndReadText

            List<string> words = new List<string>();
            var threads = new List<Thread>();
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

            #endregion

            var sortedList = words.OrderBy(x => x.Length);

            Console.WriteLine($"The shortest word is: {sortedList.FirstOrDefault()}");
        }

        static void LongestWord(string filename)
        {
            #region getAndReadText

            List<string> words = new List<string>();
            var threads = new List<Thread>();
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

            #endregion

            var sortedList = words.OrderBy(x => x.Length);

            Console.WriteLine($"The longest words is: {sortedList.LastOrDefault()}");
        }

        static void AverageWordLenght(string filename)
        {
            #region getAndReadText

            List<string> words = new List<string>();
            var threads = new List<Thread>();
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

            #endregion

            int sumOfChars = 0;

            foreach (var word in words) sumOfChars += word.Length;

            Console.WriteLine($"The average word length is: {sumOfChars / words.Count()}");
        }

        static void FiveMostCommonWords(string filename)
        {
            #region getAndReadText

            List<string> words = new List<string>();
            var threads = new List<Thread>();
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

            #endregion

            List<string> FiveMostCommonWords = new List<string>();
            FiveMostCommonWords = words.GroupBy(x => x)
                .OrderByDescending(x => x.Count())
                .Select(x => x.Key)
                .Take(5)
                .ToList();

            Console.WriteLine($"The five most common words are: {String.Join(", ", FiveMostCommonWords)}");
        }

        static void FiveLeastCommonWords(string filename)
        {
            #region getAndReadText

            List<string> words = new List<string>();
            var threads = new List<Thread>();
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

            #endregion

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

            threads = new List<Thread>();
            threads.Add(new Thread(() => CountOfWords(filename)));
            threads.Add(new Thread(() => ShortestWord(filename)));
            threads.Add(new Thread(() => LongestWord(filename)));
            threads.Add(new Thread(() => AverageWordLenght(filename)));
            threads.Add(new Thread(() => FiveMostCommonWords(filename)));
            threads.Add(new Thread(() => FiveLeastCommonWords(filename)));

            foreach (var thread in threads) thread.Start();

            foreach (var thread in threads) thread.Join();

            watch.Stop();

            Console.WriteLine($"Elapsed time = {watch.ElapsedMilliseconds} milliseconds");
        }
    }
}
