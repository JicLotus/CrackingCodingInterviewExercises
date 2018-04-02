using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises._1
{
    class _1_7 : Exercise
    {

        private int[][] buildMatrix(int n,bool empty= false)
        {
            var matrix = new int[n][];

            for (var y = 0; y < matrix.Length; y++)
            {
                matrix[y] = new int[n];
                for (var x = 0; x < n; x++)
                {
                    matrix[y][x] = empty ? 0 : x + y;
                }
            }

            return matrix;
        }

        private int[] rotateVector(int[] vector)
        {
            var rotatedVector = new int[vector.Length];

            var index = vector.Length - 1;
            for (var i = 0; i < vector.Length; i++)
            {
                var elem = vector[index + i % vector.Length];
                rotatedVector[i] = elem;
            }

            return rotatedVector;
        }



        private int[][] rotateMatrix(int[][] matrix)
        {
            var rotatedMatrix = buildMatrix(matrix.Length,true);
            var n = matrix.Length;

            for (int rot = 0;rot<(int)matrix.Length/2;rot++)
            {
                for (var i = 0; i < n - 1-2*rot; i++)
                {
                    var element = matrix[rot][rot + i];
                    rotatedMatrix[rot][rot +i+ 1] = element;

                    var element4 = matrix[n - 1 - i-rot][rot];
                    rotatedMatrix[n - 2 - i-rot][rot] = element4;

                    
                    var element2 = matrix[rot + i][n - 1 - rot];
                    rotatedMatrix[rot + i + 1][ n - 1- rot] = element2;

                    var element3 = matrix[n - 1 - rot][ n - 1 - i - rot];
                    rotatedMatrix[n - 1 - rot][n - 2 - i - rot] = element3;
                }

            }

            return rotatedMatrix;
        }


        public string result()
        {
            var n = 4;
            int[][] matrix = buildMatrix(n);
            var rotatedMatrix = rotateMatrix(matrix);
            return printMatrix(rotatedMatrix);
        }

        private string printMatrix(int[][] matrix)
        {
            var strMatrix = "";

            for (var y = 0; y < matrix.Length; y++)
            {
                var row = matrix[y];
                for (var x = 0; x < row.Length; x++)
                {
                    strMatrix += row[x];
                }
                strMatrix += "\n";
            }

            return strMatrix;
        }

    }
}
