using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises._8
{
    public class matrixPosition
    {
        public int row { get; set; }
        public int col { get; set; }
    }

    class _8_12 : Exercise
    {

        private int[][] buildMatrix(int n, int m)
        {
            var matrix = new int[n][];

            for (var i = 0; i < matrix.Length; i++)
            {
                matrix[i] = new int[m];
            }
            return matrix;
        }


        public void fillCurrentIndex(int[][] matrix, int row, int column)
        {
            for (var inc = 0; inc < matrix.Length; inc++)
            {
                matrix[row][inc] = 1;
                matrix[inc][column] = 1;
                
                if (row + inc < matrix.Length && column + inc < matrix.Length)
                {
                    matrix[row + inc][column + inc] = 1;
                }

                if (row + inc < matrix.Length && column - inc >= 0)
                {
                    matrix[row + inc][column - inc] = 1;
                }

                if (row - inc >=0 && column - inc >= 0)
                {
                    matrix[row - inc][column - inc] = 1;
                }

                if (row - inc >=0 && column + inc < matrix.Length)
                {
                    matrix[row - inc][column + inc] = 1;
                }

            }


            /*
            if (row + 1 < matrix.Length && column + 1 < matrix.Length)
            {
                matrix[row + 1][column + 1] = 1;
            }

            if (row + 1 < matrix.Length && column - 1 >= 0)
            {
                matrix[row + 1][column - 1] = 1;
            }

            if (row - 1 >= 0 && column - 1 >= 0)
            {
                matrix[row - 1][column - 1] = 1;
            }

            if (row - 1 >= 0 && column + 1 < matrix.Length)
            {
                matrix[row - 1][column + 1] = 1;
            }*/

        }

        public List<matrixPosition> getAvailableIndex(int[][] matrix)
        {
            var result = new List<matrixPosition>();

            for (var r = 0; r < matrix.Length; r++)
            {
                for (var c=0;c<matrix.Length ;c++)
                {
                    if (matrix[r][c] != 1)
                    {
                        result.Add(new matrixPosition { row = r, col = c });
                    }
                }
            }
            return result;
        }


        public void getEightQueenSolution(int[][] matrix, int row, int column, List<string> tempSoluc)
        {
            if (row >= matrix.Length || column >= matrix[0].Length)
            {
                return;
            }

            tempSoluc.Add("("+row.ToString()+","+column.ToString()+")");
            fillCurrentIndex(matrix, row, column);

            var tempMatrix = (int[][])matrix.Clone();
            var beforeTempSoluc = ((string[])tempSoluc.ToArray().Clone()).ToList();

            var possitions = getAvailableIndex(matrix);

            foreach(var poss in possitions)
            {
                getEightQueenSolution(matrix, poss.row, poss.col, tempSoluc);

                if (tempSoluc.Count == matrix.Length)
                {
                    return;
                }

                matrix = (int[][])tempMatrix.Clone();
                tempSoluc = ((string[])beforeTempSoluc.ToArray().Clone()).ToList();
            }
            
        }



        public List<string> getSolution(int[][] matrix)
        {
            List<string> solution = new List<string>();

            for (var r = 0; r < matrix.Length; r++)
            {
                var row = matrix[r];
                for (var c = 0; c < row.Length; c++)
                {
                    int[][] _matrix = buildMatrix(matrix.Length, row.Length);
                    var tempSolution = new List<string>();

                    getEightQueenSolution(_matrix, r, c, tempSolution);
                    if (tempSolution.Count == matrix.Length)
                    {
                        solution.Add(string.Join(",", tempSolution));
                    }

                }
            }
            return solution;
        }

        public string result()
        {
            int[][] matrix = buildMatrix(8, 8);
            return string.Join("\n", getSolution(matrix));
        }

    }
}
