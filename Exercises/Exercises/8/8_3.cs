using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises._8
{
    class _8_3 : Exercise
    {

        public int firstMagicIndex(int[] A)
        {
            return firstMagicIndex(A,0,A.Length-1);
        }

        //WE can optimize adding this algorithm adding Min value for left and max value for right
        public int firstMagicIndex(int[] A,int left, int right)
        {
            int middle = (left + right) / 2;

            if (right < left)
            {
                return -1;
            }

            if (A[middle] == middle)
            {
                return middle;
            }
            
            var l = firstMagicIndex(A, left, middle - 1);
            
            if (l != -1)
            {
                return l;
            }

            var r = firstMagicIndex(A, middle+1, right);

            if (r != -1)
            {
                return r;
            }
            
            return -1;
        }

        public string result()
        {
            var arr = new int[] { 1,2,3, 4,5,5,7};
            var result = firstMagicIndex(arr);

            return result.ToString();
        }

    }
}
