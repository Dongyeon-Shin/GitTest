using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitTest
{
    internal class BingoGame
    {
        public static void PlayBingoGame()
        {
            int[] bingoBoard = GetRandomNumbers(25);
            int lastSelectedPosition;
            while (true)
            {
                PrintBingoBoard(bingoBoard);
                lastSelectedPosition = GetInput(bingoBoard);
                if (CheckResult(bingoBoard, lastSelectedPosition))
                {
                    Console.WriteLine("Bingo");
                    break;
                }
            }
        }
        static int GetInput(int[] bingoBoard)
        {
            int selectedNumber;
            Console.WriteLine("Select One Number.");
            while (!int.TryParse(Console.ReadLine(), out selectedNumber) || Array.IndexOf(bingoBoard, selectedNumber) == -1)
            {
                Console.WriteLine("Wrong Value.");
            }
            selectedNumber = Array.IndexOf(bingoBoard, selectedNumber);
            bingoBoard[selectedNumber] = -1;
            return selectedNumber;
        }
        static bool CheckResult(int[] bingoBoard, int lastSelectedPosition)
        {
            bool isBingo = true;
            int i = 0;
            while (true)
            {
                if (bingoBoard[i] != -1)
                {
                    isBingo = false;
                    break;
                }
                if (i % 5 == 0)
                {
                    break;
                }
                i--;
            }
            i = 0;
            while (true)
            {
                if (bingoBoard[i] != -1)
                {
                    isBingo = false;
                    break;
                }
                if (i % 5 == 4)
                {
                    break;
                }
                i++;
            }
            if (isBingo)
            {
                return isBingo;
            }
            isBingo = true;
            i = 0;
            while (true)
            {
                if (bingoBoard[i] != -1)
                {
                    isBingo = false;
                    break;
                }
                i -= 5;
                if (i < 5)
                {
                    break;
                }
            }
            i = 0;
            while (true)
            {
                if (bingoBoard[i] != -1)
                {
                    isBingo = false;
                    break;
                }
                if (i > 19)
                {
                    break;
                }
                i += 5;
            }
            if (isBingo)
            {
                return isBingo;
            }
            isBingo = true;
            for (i = 0; i < bingoBoard.Length; i++)
            {
                if (i % 6 == 0)
                {
                    if (bingoBoard[i] != -1)
                    {
                        isBingo = false;
                        break;
                    }
                }
            }
            if (isBingo)
            {
                return isBingo;
            }
            isBingo = true;
            for (i = 0; i < bingoBoard.Length; i++)
            {
                if (i % 4 == 0)
                {
                    if (bingoBoard[i] != -1)
                    {
                        isBingo = false;
                        break;
                    }
                }
            }
            return isBingo;
        }
        static void PrintBingoBoard(int[] bingoBoard)
        {
            Console.Clear();
            int count = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (bingoBoard[count] == -1)
                    {
                        Console.Write(" X               ");
                    }
                    else if (bingoBoard[count] < 10)
                    {
                        Console.Write(" {0}               ", bingoBoard[count]);
                    }
                    else
                    {
                        Console.Write(" {0}              ", bingoBoard[count]);
                    }
                    count++;
                }
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
            }
        }
        static int[] GetRandomNumbers(int num)
        {
            Random random = new Random();
            int[] randomNumbers = new int[num];
            randomNumbers[0] = random.Next(0, 50);
            for (int i = 1; i < num; i++)
            {
                randomNumbers[i] = random.Next(0, 50);
                for (int j = i; j >= 0; j--)
                {
                    if (i == j)
                    {
                        continue;
                    }
                    if (randomNumbers[i] == randomNumbers[j])
                    {
                        randomNumbers[i] = random.Next(0, 50);
                        j = i;
                    }
                }
            }
            return randomNumbers;
        }

    }
}
