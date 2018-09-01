using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises._8
{
    class _8_12_book : Exercise
    {

        int GRID_SIZE = 8;

        public void placeQueens(int row, int[] columns, List<int[]> results)
        {
            if (row == GRID_SIZE)
            {
                results.Add((int[])columns.Clone());
            }
            else
            {
                for (int col = 0; col < GRID_SIZE; col++)
                {
                    if (checkValid(columns, row, col))
                    {
                        columns[row] = col;
                        placeQueens(row + 1, columns, results);
                    }
                }
            }
        }

        public bool checkValid(int[] columns, int row1, int column1)
        {
            for (int row2 = 0; row2 < row1; row2++)
            {
                int columns2 = columns[row2];

                if (column1 == columns2)
                {
                    return false;
                }

                int columnDistance = Math.Abs(columns2 - column1);

                int rowDistance = row1 - row2;

                if (columnDistance == rowDistance)
                {
                    return false;
                }
            }
            return true;
        }


        public string result()
        {
            var results = new List<int[]>();
            var columns = new int[GRID_SIZE];

            placeQueens(0, columns, results);
            
            return results.Count().ToString();
        }

    }
}
