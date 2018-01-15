using System;
using System.Threading;
using System.Text;

namespace Battleships
{
    class Program
    {
        // Arrays for holding the grid and alphabet
        public static string[] GridRow;
        public static string[] Alphabet = new string[25];
        public static string[,] ShipInfo = new string[,]
            {
                {"Carrier", "5", "1"},
                {"Battleship", "4", "1"},
                {"Submarine", "3", "1"},
                {"Destroyer", "2", "1"}
            };

        public static string[,] ShipLocation = new string[3, 4];
        
        // Constants for array location information
        public const int Name = 0;
        public const int Length = 1;
        public const int NumberToPlace = 2;

        static void Main(string[] args)
        {
            // Variables for menu error checking
            int Width;
            string Widthstring;
            int Height;
            string Heightstring;
            bool valid = false;

            /* Loop for checking the inputted width is within bounds and valid
               Does not allow the user to break out of the loop until it is valid */
            do
            {
                Console.WriteLine("Please enter your desired width. Must be between 1 and 26.");
                Widthstring = Console.ReadLine();
                bool res = int.TryParse(Widthstring, out Width); // Check the number that has been inputted can be converted to an int
                if (res == false || Width > 26 || Width < 0)     // If the number cannot be converted to an int, or it is wider than 26, or narrower than 1,
                {                                                // ask the user to re input a number between the bounds.
                    Console.Clear();
                    Console.WriteLine("Please choose a number between 1 and 26");
                }
                else
                {
                    valid = true;   // If it is valid, exit the loop
                }

            } while (valid == false) ;

            valid = false;  // Reset valid to false in preperation for the next loop

            /* Loop for check the inputted height in within bounds and valid.
               Please see last loop for a detailed description */
            do
            {
                Console.WriteLine("Please enter your desired height. Must be between 1 and 26.");
                Heightstring = Console.ReadLine();
                bool resb = int.TryParse(Heightstring, out Height);
                if (resb == false || Height > 26 || Height < 0)
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
          

            SetupGame(Width, Height + 1);   // Parse the Width and Height variables to the SetupGame function.  Height + 1 to allow for the letter header of the grid
            DrawGrid();                     // Draw the grid
            PlayGame(Width, Height);        // TODO:  Play Game Function
          
            Console.Read();                 // Read from the console to pause the program
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
            // Populates grid.
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

        static void PlayGame(int Width, int Height)
        {
            char co_x;
            string stringx;
            char co_y;
            string stringy;
            bool valid = false;
          

            Console.WriteLine("Where are you attacking?");

            do
            {
                Console.WriteLine("Please enter the x co-ordinate you would like to attack");
                stringx = Console.ReadLine();
                bool res = char.TryParse(stringx, out co_x);
                if (res == false)
                {
                    Console.Clear();
                    Console.WriteLine("Please choose a letter on the grid");
                }
                else
                {
                    valid = true;
                   
                }

            } while (valid == false);

            valid = false;

            do
            {
                Console.WriteLine("Please enter the y co-ordinate you would like to attack");
                stringy = Console.ReadLine();
                bool resb = char.TryParse(stringy, out co_y);
                if (resb == false)
                {
                    Console.Clear();
                    Console.WriteLine("Please choose a letter on the grid");
                }
                else
                {
                    valid = true;
                }

            } while (valid == false);

        }
    }
}
