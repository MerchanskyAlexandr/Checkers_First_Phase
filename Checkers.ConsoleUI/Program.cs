using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkers.GameEngine;
using System.Drawing;
using System.IO;

namespace Checkers
{
    class Program
    {
        static void Main(string[] args)
        {
            string messageEndGame;
            string messageMove = "White Player is moving";
            GameType typeOfGame;
            Player currentPlayer;
            string message;

            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetWindowSize(50, 50);

            typeOfGame = EnterTypeOfGame();
            Game game = new Game(typeOfGame);

            if (typeOfGame == GameType.SinglePlayer)
            {
                while (!game.IsExit())
                {
                    List<Point> lightPoints = new List<Point>();
                    Console.Clear();
                    lightPoints = game.WhitePlayer.LightPoints;
                    if (lightPoints != null)
                    {
                        PrintPoints(lightPoints);
                    }
                    Console.WriteLine();
                    PrintDesk(game.GameDesk);
                    Console.WriteLine();
                    Point point = EnterPoint();
                    game.RunGameWithComputer(point);
                }
                Console.WriteLine("END GAME. {0} wins.", game.WinnerColor);
            }

            if (typeOfGame == GameType.MultyPlayer)
            {
                while (!game.IsExit())
                {
                    List<Point> lightPoints = new List<Point>();
                    Console.Clear();
                    currentPlayer = game.CurrentPlayer;
                    lightPoints = currentPlayer.LightPoints;
                    if (lightPoints != null)
                    {
                        PrintPoints(lightPoints);
                    }
                    Console.WriteLine();
                    PrintDesk(game.GameDesk);
                    Console.WriteLine("{0} Player is moving", currentPlayer.Color);
                    Point point = EnterPoint();
                    game.RunGame(point);
                }
                Console.WriteLine("END GAME. {0} wins.", game.WinnerColor);
            }
        }

        public static GameType EnterTypeOfGame()
        {
            byte t;
            Console.WriteLine("Enter Type Of Game.");
            Console.WriteLine("1 - Player vs Player");
            Console.WriteLine("2 - Player vs Computer");

            Console.Write("Type = ");
            bool result = Byte.TryParse(Console.ReadLine(), out t);
            while ( !result || !(t == 1 || t == 2) )
            {
                Console.WriteLine("Wrong Type. Enter one more please");
                Console.Write("Type = ");
                result = Byte.TryParse(Console.ReadLine(), out t);
            }
            return t == 1 ? GameType.MultyPlayer : GameType.SinglePlayer;
        }

        public static Point EnterPoint()
        {
            int x, y;
            Console.WriteLine();            
            Console.Write("X = ");
            bool result = Int32.TryParse(Console.ReadLine(), out x);
            while (!result)
            {
                Console.WriteLine("Its not coordinate. Enter one more please");
                Console.Write("X = ");
                result = Int32.TryParse(Console.ReadLine(), out x);
            }

            Console.Write("Y = ");
            result = Int32.TryParse(Console.ReadLine(), out y);
            while (!result)
            {
                Console.WriteLine("Its not coordinate. Enter one more please");
                Console.Write("Y = ");
                result = Int32.TryParse(Console.ReadLine(), out y);
            }

            return new Point(x, y);
        }

        public static void PrintPoints(List<Point> points)
        {
            if (points != null)
            {
                Console.WriteLine("Possible moves: ");
                foreach (Point p in points)
                {
                    Console.Write("[{0}, {1}], ", p.X, p.Y);
                }
            }
        }

        public static string PrintChecker(CheckerOnDesk chD)
        {
            string s;

            if (chD.Status == CheckerStatus.Simple)
            {
                s = (chD.Color == ColorType.White) ? "☺" : "☻";
            }
            else
            {
                s = (chD.Color == ColorType.White) ? "¤" : "♣";
            }

            return s;
        }

        public static void PrintDesk(Desk desk)
        {
            List<CheckerOnDesk> checkersOnDesk = desk.GetCheckersOnDesks;

            char[] ch = new[] {'┬', '─', '─', '─', '┬'};
            char[] ch2 = new[] { '┼', '─', '─', '─', '┬' };

            Console.Write("  ");
            for (int k = 1; k <= 8; k++)
            {
                Console.Write(ch, 0, 4);
            }
            Console.Write('┐');
            Console.WriteLine();

            for (int i = 7; i >= 0; i--)
            {
                Console.Write(i + " ");
                for (int j = 0; j < 8; j++)
                {
                    Point p = new Point(i, j);
                    if (desk.GetCheckerOnDesk(p) != null)
                    {
                        CheckerOnDesk chD = desk.GetCheckerOnDesk(p);
                        Console.Write('│' + " " + PrintChecker(chD) + " ");
                    }
                    else
                    {
                        Console.Write('│' + " " + " " + " ");
                    }
                }
                Console.Write('│');
                Console.WriteLine("  ");
                Console.CursorLeft = 2;
                for (int k = 1; k <= 8; k++)
                {
                    Console.Write(ch2, 0, 4);
                }
                Console.Write('┤');
                Console.WriteLine();
            }
            Console.WriteLine("    0   1   2   3   4   5   6   7");
        }
    }
}
