using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitTest
{
    internal class UpDownGame
    {
        public static void StartUpDownGame()
        {
            Random random = new Random();
            int comNumber = random.Next(0, 1000);
            int guessNumber;
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Select Number. 0 ~ 999");
                while (!(int.TryParse(Console.ReadLine(), out guessNumber)) || guessNumber > 999 || guessNumber < 0)
                {
                    Console.WriteLine("Wrong Value.");
                }
                if (i == 9)
                {
                    Console.WriteLine("Game Over.");
                    Console.WriteLine(" Continue? Press Enter.");
                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                    {
                        i = -1;
                        comNumber = random.Next(0, 1000);
                    }
                    else
                    {
                        break;
                    }

                }
            }
        }

    }
}
