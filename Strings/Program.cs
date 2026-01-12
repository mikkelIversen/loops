using System;
using System.Linq;

namespace Strings
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(AddSeparator("ABCD", '^'));
            Console.WriteLine(IsPalindrome("eye"));
            Console.WriteLine(IsPalindrome("home"));
            Console.WriteLine(LengthOfString("computer"));
            Console.WriteLine(Reverse("qwerty"));
            Console.WriteLine(NumberOfWords("This is a sample sentence"));
            Console.WriteLine(RevertWordsOrder("Jonh Doe"));
            Console.WriteLine(HowManyOccurrences("do it now", "do"));
            Console.WriteLine(SortCharactersDescending("onomatopoeia"));
            Console.WriteLine(SortCharactersDescending("fohjwf42os"));
            Console.WriteLine(CompressString("kkkktttrrrrrrrrrr"));
        }

        public static string AddSeparator(string text, char separator)
        {
            char[] chars = text.ToCharArray();
            string result = "";
            foreach (char c in chars)
            {
                result += c;
                result += separator;
            }
            return result;
        }

        public static bool IsPalindrome(string text)
        {
            return new string(text.Reverse().ToArray()).Equals(text);
        }

        public static int LengthOfString(string text)
        {
            return text.Length;
        }

        public static string Reverse(string text)
        {
            return new string(text.Reverse().ToArray());
        }

        public static int NumberOfWords(string text)
        {
            string[] words = text.Split(' ');
            return words.Length;
        }

        public static string RevertWordsOrder(string text)
        {
            string[] words = text.Split(' ');
            words = words.Reverse().ToArray();
            return string.Join(" ", words);
        }

        public static int HowManyOccurrences(string text, string matcher)
        {
            string[] words = text.Split(' ');
            int count = 0;
            foreach (string word in words)
            {
                if (word == matcher) count++;
            }
            
            return count;
        }
        
        static string SortCharactersDescending(string input)
        {
            var letters = input
                .OrderByDescending(c => c);

            return new string(letters.ToArray());
        }
        public static string CompressString(string text)
        {
            string result = "";
            char lastChar = text[0];
            int count = 0;

            foreach (char c in text)
            {
                if (lastChar != c)
                {
                    result += lastChar;
                    result += count;
                    count = 0;
                    lastChar = c;
                }
                count++;
            }
            result += lastChar;
            result += count;
            return result;
        }
    }
}