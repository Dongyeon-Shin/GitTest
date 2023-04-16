using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitTest
{
    public class Puzzle
    {
        protected int[] _puzzleBoard = new int[25];
        public int[] PuzzleBoard
        {
            get { return _puzzleBoard; }
            set { _puzzleBoard = value; }
        }
        protected int _playerPosition;
        public int PlayerPosition
        {
            get { return _playerPosition; }
            set { _playerPosition = value; }
        }
        public void Shuffle()
        {
            Random random = new Random();
            _puzzleBoard[0] = random.Next(0, 25);
            _playerPosition = 0;
            for (int i = 1; i < 25; i++)
            {
                _puzzleBoard[i] = random.Next(0, 25);
                for (int j = i; j >= 0; j--)
                {
                    if (i == j)
                    {
                        continue;
                    }
                    if (_puzzleBoard[i] == _puzzleBoard[j])
                    {
                        _puzzleBoard[i] = random.Next(0, 25);
                        j = i;
                    }
                }
                if (_puzzleBoard[i] == 0)
                {
                    _playerPosition = i;
                }
            }
        }
        public void PrintPuzzleBoard()
        {
            Console.Clear();
            int count = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (_puzzleBoard[count] == 0)
                    {
                        Console.Write(" X               ");
                    }
                    else if (_puzzleBoard[count] < 10)
                    {
                        Console.Write(" {0}               ", _puzzleBoard[count]);
                    }
                    else
                    {
                        Console.Write(" {0}              ", _puzzleBoard[count]);
                    }
                    count++;
                }
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
    public class Player
    {
        enum Input
        {
            None,
            Left,
            Right,
            Up,
            Down
        }
        ConsoleKeyInfo info;
        Input input;
        public void GetKeyInput()
        {
            info = Console.ReadKey();
            switch (info.Key)
            {
                case ConsoleKey.LeftArrow:
                    input = Input.Left;
                    break;
                case ConsoleKey.RightArrow:
                    input = Input.Right;
                    break;
                case ConsoleKey.UpArrow:
                    input = Input.Up;
                    break;
                case ConsoleKey.DownArrow:
                    input = Input.Down;
                    break;
                default:
                    input = Input.None;
                    break;
            }
        }
        public void Move(Puzzle puzzle)
        {
            int prevPlayerPosition = puzzle.PlayerPosition;
            switch(input)
            {
                case Input.Left:
                    if (prevPlayerPosition % 5 != 0)
                    {
                        puzzle.PlayerPosition -= 1;
                    }
                    break;
                case Input.Right:
                    if (prevPlayerPosition % 5 != 4)
                    {
                        puzzle.PlayerPosition += 1;
                    }
                    break;
                case Input.Up:
                    if (prevPlayerPosition > 4)
                    {
                        puzzle.PlayerPosition -= 5;
                    }
                    break;
                case Input.Down:
                    if (prevPlayerPosition < 20)
                    {
                        puzzle.PlayerPosition += 5;
                    }
                    break;
                default:
                    {
                        break;
                    }
            }
            puzzle.PuzzleBoard[prevPlayerPosition] = puzzle.PuzzleBoard[puzzle.PlayerPosition];
            puzzle.PuzzleBoard[puzzle.PlayerPosition] = 0;
        }
    }
    internal class SlidePuzzleGame
    {
        public void Play()
        {
            Puzzle puzzle = new Puzzle();
            Player player = new Player();
            puzzle.Shuffle();
            puzzle.PrintPuzzleBoard();
            while (true)
            {
                player.GetKeyInput();
                player.Move(puzzle);
                puzzle.PrintPuzzleBoard();
            }
        }
    }
}
