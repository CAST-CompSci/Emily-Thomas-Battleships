using System;
using System.Threading;

namespace Battleships
{
    class Program
    {
        // Arrays for holding the grid and alphabet
        protected static string[] GridRow;
        protected static string[] Alphabet = new string[25];
        protected static string[,] ShipInfo = new string[3, 2];

        protected const int Name = 0;
        protected const int Length = 1;
        protected const int NumberToPlace = 2;

        static void Main(string[] args)
        {
            SetupGame(20, 20);
            DrawGrid();
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

        static void PlaceShips()
        {
            ShipInfo = new string[,]
            {
                {"Carrier", "5", "1"},
                {"Battleship", "4", "1"},
                {"Submarine", "3", "1"},
                {"Destroyer", "2", "1"}
            };
        }


        static void DrawGrid()
        {
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
            PlaceShips();           
        }

        static int GetRandomNumber(int min, int max)
        {
            Random random = new Random();

            return random.Next(min, max);
        }
    }
}
