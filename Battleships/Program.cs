using System;
using System.Threading;

namespace Battleships
{
    class Program
    {
        // Arrays for holding the grid and alphabet
        public static string[] GridRow;
        public static string[] Alphabet = new string[25];
        public static string[,] ShipInfo = new string[3, 2];

        public const int Name = 0;
        public const int Length = 1;
        public const int NumberToPlace = 2;

        static void Main(string[] args)
        {
            int Width;
            string Widthstring;
            int Height;
            string Heightstring;
            bool valid = false;

            do
            {
                Console.WriteLine("Please enter your desired width. Must be between 1 and 26.");
                Widthstring = Console.ReadLine();
                bool res = int.TryParse(Widthstring, out Width);
                if (res == false || Width > 26 || Width < 0)
                {
                    Console.Clear();
                    Console.WriteLine("Please choose a number between 1 and 26");
                }
                else
                {
                    valid = true;
                }

            } while (valid == false) ;

            valid = false;

            do
            {
                Console.WriteLine("Please enter your desired height. Must be between 1 and 26.");
                Heightstring = Console.ReadLine();
                bool resb = int.TryParse(Heightstring, out Height);
                if (resb == false || Width > 26 || Width < 0)
                {
                    Console.Clear();
                    Console.WriteLine("Please choose a number between 1 and 26");
                }
                else
                {
                    valid = true;
                }

            } while (valid == false);

            Console.Clear();
          
            SetupGame(Width, Height + 1);
            DrawGrid();
            PlaceShips(5);

            Console.Read();
        }

        static void GenerateGrid(int Width, int Height)
        {
            GridRow = new string[Height + 1];
            GridRow[0] = " ";

            for (int i = 0; i < Width; i++)
            {
                GridRow[0] += " " + Alphabet[i];
            }

            for (int i = 1; i < Height; i++)
            { 
                GridRow[i] = Alphabet[i - 1] + " ";
            }

            for (int ia = 1; ia < Height; ia++)
            {
                for (int ib = 0; ib < Width; ib++)
                {
                    GridRow[ia] += "x ";
                }
            }          
        }

        static void PlaceShips(int row)
        {
            ShipInfo = new string[,]
            {
                {"Carrier", "5", "1"},
                {"Battleship", "4", "1"},
                {"Submarine", "3", "1"},
                {"Destroyer", "2", "1"}
            };

            Char Seperator = ' ';
            String[] RowData = GridRow[row].Split(Seperator);
            GridRow[row] = "";

            RowData[2] = "O";

            foreach (var column in RowData)
            {
                GridRow[row] += column + " ";
            }

            DrawGrid();
        }



        static void DrawGrid()
        {
            Console.Clear();
            foreach (var row in GridRow)
            {
                Console.WriteLine(row);
                Thread.Sleep(0);
            }
        }

        static void SetupGame(int width, int height)
        {
            int i = 0;
            for (char c = 'A'; c < 'Z'; c++)
            {
                Alphabet[i] = c.ToString();
                i += 1;
            }

            GenerateGrid(width, height);
            // PlaceShips(5);           
        }

        static int GetRandomNumber(int min, int max)
        {
            Random random = new Random();

            return random.Next(min, max);
        }

    }
}
