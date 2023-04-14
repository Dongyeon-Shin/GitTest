using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitTest
{
    internal class ImplementFunctions
    {
        static void FindWord()
        {
            string sentence = Console.ReadLine();
            string word = Console.ReadLine(); ;
            Console.WriteLine(sentence.LastIndexOf(word));
        }
        static void CountWords()
        {
            string sentence = Console.ReadLine();
            char space = ' ';
            int count = 1;
            foreach (char c in sentence)
            {
                if (c == space)
                {
                    count++;
                }
            }
            Console.WriteLine(count);
        }
        static bool IsPrime(int n)
        {
            for (int i = 2; i < n; i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

    }
}
