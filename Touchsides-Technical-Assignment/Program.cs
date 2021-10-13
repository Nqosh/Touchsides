using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Touchsides_Technical_Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            String line;
            List<string> words = new List<string>();
            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Users\CT301728\Documents\WarandPeace.txt");

            //Reads each line  
            while ((line = file.ReadLine()) != null)
            {
                String[] string1 = line.ToLower().Split(new Char[] { ',', '.', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                //Adding all words generated in previous step into words  
                foreach (String s in string1)
                {
                    words.Add(s);
                }
            }

            var mostRepeatedWord = words.SelectMany(x => x.Split(new[] { " " },
                                                 StringSplitOptions.RemoveEmptyEntries))
                                 .GroupBy(x => x).OrderByDescending(x => x.Count())
                                 .Select(x => new { KeyField = x.Key, Count = x.Count() }).FirstOrDefault();

            var mostRepeatedSevenCharacterWord = words.Where(x => x.Length == 7).SelectMany(x => x.Split(new[] { " " },
                                                 StringSplitOptions.RemoveEmptyEntries)).GroupBy(x => x)
                                            .Select(x => new
                                            {
                                                KeyField = x.Key,
                                                Count = x.Count()
                                            }).OrderByDescending(x => x.Count).FirstOrDefault();

            var wordsFromListWithMaxLength = words.SelectMany(x => x.Split(new[] { " " },
                                                 StringSplitOptions.RemoveEmptyEntries)).Distinct();

            var results = ScoreofWord(wordsFromListWithMaxLength.ToList());

            var highestScoringString = results.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
            var highestScoringStringVal = results.Aggregate((l, r) => l.Value > r.Value ? l : r).Value;

            Console.WriteLine("Most frequent word: " + mostRepeatedWord.KeyField + " " + "occurred" + " " + mostRepeatedWord.Count);
            Console.WriteLine("Most Seven Character repeated word: " + mostRepeatedSevenCharacterWord.KeyField + " " + "occurred" + " " + mostRepeatedSevenCharacterWord.Count);
            Console.WriteLine("Highest scoring word(s) (according to the score table): " + highestScoringString + " " + "with a score of " + " " + highestScoringStringVal);
            file.Close();
        }

        private static Dictionary<string, int> ScoreofWord(List<string> words)
        {
            int sum = 0;
            Dictionary<string, int> myDict = new Dictionary<string, int>();

            foreach (var word in words)
            {
                if (word.Contains("a"))
                {
                    sum = sum + 1;
                }
                if (word.Contains("b"))
                {
                    sum = sum + 3;
                }
                if (word.Contains("c"))
                {
                    sum = sum + 3;
                }
                if (word.Contains("d"))
                {
                    sum = sum + 2;
                }
                if (word.Contains("e"))
                {
                    sum = sum + 1;
                }
                if (word.Contains("f"))
                {
                    sum = sum + 4;
                }
                if (word.Contains("g"))
                {
                    sum = sum + 2;
                }
                if (word.Contains("h"))
                {
                    sum = sum + 4;
                }
                if (word.Contains("i"))
                {
                    sum = sum + 1;
                }
                if (word.Contains("j"))
                {
                    sum = sum + 8;
                }
                if (word.Contains("k"))
                {
                    sum = sum + 5;
                }
                if (word.Contains("l"))
                {
                    sum = sum + 1;
                }
                if (word.Contains("m"))
                {
                    sum = sum + 3;
                }
                if (word.Contains("n"))
                {
                    sum = sum + 1;
                }
                if (word.Contains("o"))
                {
                    sum = sum + 1;
                }
                if (word.Contains("p"))
                {
                    sum = sum + 3;
                }
                if (word.Contains("q"))
                {
                    sum = sum + 10;
                }
                if (word.Contains("r"))
                {
                    sum = sum + 1;
                }
                if (word.Contains("s"))
                {
                    sum = sum + 1;
                }
                if (word.Contains("t"))
                {
                    sum = sum + 1;
                }
                if (word.Contains("u"))
                {
                    sum = sum + 1;
                }
                if (word.Contains("v"))
                {
                    sum = sum + 4;
                }
                if (word.Contains("w"))
                {
                    sum = sum + 4;
                }
                if (word.Contains("x"))
                {
                    sum = sum + 8;
                }
                if (word.Contains("y"))
                {
                    sum = sum + 4;
                }
                if (word.Contains("z"))
                {
                    sum = sum + 10;
                }
                myDict.Add(word, sum);
                sum = 0;
            }

            return myDict;
        }
    }
}
