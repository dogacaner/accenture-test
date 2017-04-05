using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DogaCanerTest
{
    public class Program
    {
        private const char replacementChar = (char) 42;

        static void Main(string[] args)
        {
            ShowInformation();
            while (true)
            {
                var val = Console.ReadLine();
                if (val.ToLower() == "c")
                    NewQuestion();
                else if (val.ToLower() == "r")
                    OldQuestion();
                else if (val.ToLower() == "q")
                    break;
                else
                    Console.WriteLine("Please enter a valid string value!");
            }
        }

        public static void NewQuestion()
        {
            var stringInput = GetUserStringInput("String:");
            var repeatCount = GetUserIntInput("Repeat Count:");
            var changedString = ChangeRepeatedCharacters(stringInput, repeatCount);
            Console.WriteLine("Result: " + changedString);
            ShowInformation();
            Console.ReadLine();
        }

        public static string ChangeRepeatedCharacters(string input, int repeatCount)
        {
            var index = 0;
            var lastChar = new char(); //save last character for comparison
            var charCount = 1; //initial repeated characters count
            var repeatedIndex = new List<int>(); //list of repeated characters index
            
            var array = input.ToCharArray();
            foreach (var character in array)
            {
                if (character == lastChar)
                {
                    charCount++;
                }
                else
                {
                    if (charCount >= repeatCount)//if repeated character count is more than limit, change all characters to *
                    {
                        foreach (var i in repeatedIndex)
                        {
                            array[i] = replacementChar;
                        }
                    }
                    charCount = 1;
                    repeatedIndex.Clear();
                }
                repeatedIndex.Add(index);
                
                lastChar = character;
                index++;
            }

            return new string(array);
        }

        #region Old Question
        public static void OldQuestion()
        {
            var stringInput = GetUserStringInput("String:");
            var repeatCount = GetUserIntInput("Repeat Count:");
            var removedString = RemoveRepeatedCharacters(stringInput, repeatCount);
            Console.WriteLine("Result: " + removedString);
            ShowInformation();
            Console.ReadLine();
        }

        public static string RemoveRepeatedCharacters(string input, int repeatCount)
        {
            var repeatedChars = input.GroupBy(c => c).Where(x => x.Count() >= repeatCount && (!char.IsWhiteSpace(x.Key))).Select(x => x.First().ToString()).ToList();
            return repeatedChars.Aggregate(input, (current, result) => current.Replace(result, "")).Trim();
        }
        #endregion

        #region Helpers
        public static void ShowInformation()
        {
            Console.WriteLine("Press C to change consecutive repeated characters.");
            Console.WriteLine("Press R to remove repeated characters.");
            Console.WriteLine("Press Q to exit");
        }
        static string GetUserStringInput(string inputQuery)
        {
            Console.Write(inputQuery);
            string val;
            while (true)
            {
                val = Console.ReadLine();
                if (String.IsNullOrEmpty(val))
                    Console.WriteLine("Please enter a valid string value!");
                else
                    break;
            }
            return val;
        }
        static int GetUserIntInput(string inputQuery)
        {
            Console.Write(inputQuery);
            int val;
            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out val))
                    Console.WriteLine("Please enter a valid int value");
                else
                    break;
            }
            return val;
        }
        #endregion
    }
}
