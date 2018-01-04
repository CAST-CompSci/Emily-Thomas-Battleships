using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    class Program
    {
        // Arrays for holding the grid and alphabet
        public static string[] GridRow;
        public static string[] Alphabet = new string[25];

        static void Main(string[] args)
        {
            SetupGame();
            DrawGrid(20, 10);
            Console.Read();
        }

        static void DrawGrid(int Width, int Height)
        {
            GridRow = new string[Height + 1];
            GridRow[0] = " ";

            for (int i = 0; i < Width; i++)
            {
                GridRow[0] += " " + Alphabet[i];
            }

            for (int i = 1; i < Height; i++)
            {
                GridRow[i] = i.ToString() + " ";
            }

            for (int ia = 1; ia < Height; ia++)
            {
                for (int ib = 0; ib < Width; ib++)
                {
                    GridRow[ia] += "X ";
                }
            }

            foreach (var row in GridRow)
            {
                Console.WriteLine(row);
            }           
        }

        static void SetupGame()
        {
            int i = 0;
            for (char c = 'A'; c < 'Z'; c++)
            {
                Alphabet[i] = c.ToString();
                i += 1;
            }
        }
    }
}
