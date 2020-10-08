using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.IO;

namespace ShuffleLetters
{
    class Program
    {
        static string input_path=@"lib/abc-hu-simple-letters.txt";
        
        static void Main(string[] args)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            List<string> alphabetList = AoCBeolvaso.Beolvas.Reader("ShuffleLetters.lib.abc-hu-simple-letters-string.txt");
            string[] alphabet = alphabetList[0].Split(", ");
            
            Console.WriteLine("This program shuffle the letters of words, except the first and the last letter, and the sentence still readable!");
            Console.WriteLine("Please write the sentences below:");
            
            string input = Console.ReadLine(), shuffledString = "";

            while (input.Length > 0)
            {
                string word = "";
                while (alphabet.Contains(input[0].ToString()))
                {
                    word += input[0];
                    input = input.Remove(0, 1);

                    if (input.Length == 0) break;
                }

                if (word.Length > 3)
                {
                    word = shuffleFunction(word);
                }
                
                if (input.Length > 0)
                {
                    word += input[0];
                    input = input.Remove(0, 1);
                }
                shuffledString += word;
                word = "";
            }
            
            Console.WriteLine("Lets try to read the result below!");
            Console.WriteLine(shuffledString);
            
            watch.Stop();
            var elapsed = watch.Elapsed;
            Console.WriteLine(elapsed);
        }

        static string shuffleFunction(string word)
        {
            string shuffledWord = "";
            char lastLetter;
            shuffledWord += word[0];
            lastLetter = word[word.Length - 1];
            word = word.Remove(0, 1);
            word = word.Remove(word.Length - 1, 1);
            HashSet<int> letters = new HashSet<int>();
            Random rnd = new Random();
            while (letters.Count < word.Length)
            {
                letters.Add(rnd.Next(0, word.Length));
            }

            foreach (var index in letters)
            {
                shuffledWord += word[index];
            }

            shuffledWord += lastLetter;
            return shuffledWord;
        }
    }
}