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
            int Width = 0;
            string Widthstring;
            int Height = 0;
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
            DrawGrid(Width, Height);
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
                GridRow[i] = Alphabet[i - 1] + " ";
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
