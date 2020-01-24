using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratory
{
    public class GetXYBySequenceNumber
    {
        int[,] _grid;


        //////////// IMPORTANT STUFF ///////////////

        public int FindX(int sequenceNum, int[,] grid)
        {
            int numberOfColumns = grid.GetLength(1);

            int x = sequenceNum - (int)((Math.Ceiling((decimal)sequenceNum / numberOfColumns) - 1) * numberOfColumns);

            return x;
        }

        public int FindY(int sequenceNum, int[,] grid)
        {
            int numberOfColumns = grid.GetLength(1);
            int y = (int)(Math.Ceiling((decimal)sequenceNum / numberOfColumns));
            return y;
        }

        //////////// PRESENTATION STUFF ///////////////

        public GetXYBySequenceNumber()
        {
            Greet();
        }

        public Dictionary<string, int> FindXYOfSequenceNumber(int sequenceNum, int[,] grid)
        {
            var dict = new Dictionary<string, int>();

            dict.Add("row", FindY(sequenceNum, grid));
            dict.Add("col", FindX(sequenceNum, grid));

            return dict;
        }

        public void Greet()
        {
            Console.WriteLine("what size grid would you like?");
            var gridInput = Console.ReadLine();
            var gridDict = ParseGridInput(gridInput);
            int rows = gridDict.TryGetValue("rows", out rows) ? rows : 0;
            int cols = gridDict.TryGetValue("cols", out cols) ? cols : 0;

            DrawGrid(rows, cols);
        }

        public void DrawGrid(int rows, int cols)
        {
            Console.Clear();

            _grid = PrintGrid(rows, cols);

            Console.WriteLine("\n\n Enter a sequence number: ");
            string sequenceInput = Console.ReadLine();

            int sequenceNum = int.TryParse(sequenceInput, out sequenceNum) ? sequenceNum : 1;

            var dict = FindXYOfSequenceNumber(sequenceNum, _grid);

            int x = dict.TryGetValue("col", out x) ? x : -1;
            int y = dict.TryGetValue("row", out y) ? y : -1;

            Console.WriteLine($"\nThe co-ordinates of {sequenceNum} is: \t [{x},{y}]");

            string option = Console.ReadLine();

            if (option == "x")
            {
                Console.Clear();
                Greet();
            }
            else
            {
                DrawGrid(rows, cols);
            }
        }

        public Dictionary<string, int> ParseGridInput(string input)
        {
            var dict = new Dictionary<string, int>();

            int rows = 0;
            int cols = 0;

            string[] array = input.Split(',');

            if(array.Length >= 2)
            {
                rows = int.TryParse(array[0], out rows) ? rows : 0;
                cols = int.TryParse(array[1], out cols) ? cols : 0;
            }

            dict.Add("rows", rows);
            dict.Add("cols",cols);

            return dict;
        }

        public int[,] CreateGrid(int rows, int cols)
        {
            var grid = new int[rows, cols];
            int series = 1;

            for(int r = 0; r < rows; r++)
            {
                for(int c = 0; c < cols; c++)
                {
                    grid[r, c] = series;
                    series++;
                }
            }

            return grid;
        }

        public void PrintGrid(int[,] grid)
        {
            string output;

            for (int r = 0; r < grid.GetLength(0); r++)
            {
                output = "";

                for (int c = 0; c < grid.GetLength(1); c++)
                {
                    output += grid[r,c].ToString() + "\t";
                }
                Console.WriteLine(output + "\n");
            }
        }

        public int[,] PrintGrid(int rows, int cols)
        {
            var grid = CreateGrid(rows, cols);
            PrintGrid(grid);
            return grid;
        }
    }
}
