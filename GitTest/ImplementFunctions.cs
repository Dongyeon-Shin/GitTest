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
        static int SumOfDigits(int num)
        {
            int sum = 0;
            for (int i = num; i > 0; i /= 10)
            {
                sum += i % 10;
            }
            return sum;
        }
        static int[] FindCommonItems(int[] arr1, int[] arr2, int[] arr3)
        {
            List<int> commonNumbers = new List<int>();

            for (int i = arr1.Min(); i <= arr1.Max(); i++)
            {
                foreach (int item in arr1)
                {
                    if (i == item)
                    {
                        foreach (int item2 in arr2)
                        {
                            if (item == item2)
                            {
                                foreach (int item3 in arr3)
                                {
                                    if (item == item3)
                                    {
                                        commonNumbers.Add(item);
                                        break;
                                    }
                                }
                                break;
                            }

                        }
                        break;
                    }
                }
            }
            return commonNumbers.ToArray();
        }

    }
}
