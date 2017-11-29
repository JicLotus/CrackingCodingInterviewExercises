using Exercises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises._8
{
    public class _8_2 : Exercise
    {

        public _8_2()
        {
        }


        public bool getValidPath(int[][] matrix,int right,int down,List<string> resultado)
        {
            if (right >= matrix.Length || down >= matrix[right].Length)
            {
                return false;
            }

            if (right == matrix.Length-1 && down == matrix[right].Length-1)
            {
                var path = "(" + right.ToString() + "," + down.ToString() + ")";
                resultado.Add(path);
                return true;
            }

            if (matrix[right][down] == 1)
            {
                return false;
            }

            
            var result1 = getValidPath(matrix, right + 1, down, resultado);

            if (result1)
            {
                var actualPath = "(" + right.ToString() + "," + down.ToString() + ")";
                resultado.Add(actualPath);

                return true;
            }
            
            var result2 = getValidPath(matrix, right, down+ 1, resultado);

            if (result2)
            {
                var actualPath = "(" + right.ToString() + "," + down.ToString() + ")";
                resultado.Add(actualPath);

                return true;
            }


            return false;
        }

        public string result()
        {
            int cantidadColumnas = 5;
            int cantidadFilas = 3;

            int[][] matrix = makeMatrix(cantidadFilas, cantidadColumnas);
            List<string> resultado = new List<string>();


            //Restricciones
            //matrix[1][0] = 1;
            //matrix[1][2] = 1;
            //matrix[0][2] = 1;

            getValidPath(matrix, 0, 0, resultado);
            
            var strResult = "";
            foreach (var str in resultado)
            {
                strResult += str;
            }

            return strResult;
        }

        private int[][] makeMatrix(int cantidadFilas,int cantidadColumnas)
        {
            int[][] matrix = new int[cantidadFilas][];
            
            for (int r = 0; r < cantidadFilas; r++)
            {
                matrix[r] = new int[cantidadColumnas];

                for (int c = 0; c < cantidadColumnas; c++)
                {
                    matrix[r][c] = 0;
                }
            }

            return matrix;
        }

    }
}
