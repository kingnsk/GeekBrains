using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bl2_less4_1
{


    class Program
    {
        static void Main(string[] args)
        {
            var user_text = new textDataBenchmark();
            var searchText = "Santa" ;

            Console.WriteLine($"Поиск слова {searchText} перебором массива:{user_text.searchString()}  через хэш:{user_text.searchHash()}");
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
        }
    }

    public class textDataBenchmark
    {
        public static int num_letters = 5;
        public static int num_words = 10000;
        public string[] words = new string[num_words];
        public HashSet<string> hashSet;

        public string text { get; set; }

        public override bool Equals(object obj)
        {
            var text_string = obj as textDataBenchmark;

            if (text_string == null)
                return false;

            return text == text_string.text;
        }

        public override int GetHashCode()
        {
            int textHashCode = text?.GetHashCode() ?? 0;
            return textHashCode;
        }

        public textDataBenchmark()
        {
            hashSet = new HashSet<string>();
            Random rand = new Random();
            char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            for (int i = 1; i <= num_words; i++)
            {
                string word = "";
                for (int j = 1; j <= num_letters; j++)
                {
                    int letter_num = rand.Next(0, letters.Length - 1);
                    word += letters[letter_num];
                }

                words[i - 1] = word;
                hashSet.Add(word);
            }

            // заносим в массив и hashSet слово, которое будем искать
            words[words.Length-1] = "Santa";
            hashSet.Add(words[words.Length-1]);

            //for (int i = 0; i < words.Length; i++)
            //{
            //    Console.WriteLine($"{i} = {words[i]}");
            //}
        }

        [Benchmark]
        public bool searchString()
        {
            string search = "Santa ";
            for (int i = 0; i < words.Length; i++)
            {
                if(search == words[i])
                {
                    return true;
                }
            }
            return false;
        }

        [Benchmark]
        public bool searchHash()
        {
            string search = "Santa";
            return hashSet.Contains(search);
        }
    }
}
