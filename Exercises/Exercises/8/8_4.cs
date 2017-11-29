using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises._8
{
    public class _8_4 : Exercise
    {
        
        
        public List<List<int>> allSubSets(int[] arr,int incr)
        {
            if (incr==arr.Length)
            {
                var subSet = new List<int>();
                var subSubSet = new List<List<int>>();
                subSubSet.Add(subSet);
                return subSubSet;
            }

            var allSubsets = allSubSets(arr, incr+1);
            var actualItem = arr[incr];

            var tempSubSet = new List<List<int>>();

            foreach (var subSet in allSubsets)
            {
                var newSubSet = new List<int>();
                newSubSet.Add(actualItem);
                newSubSet.AddRange(subSet);

                tempSubSet.Add(newSubSet);
            }
            
            allSubsets.AddRange(tempSubSet);

            return allSubsets;
        }

        public string result()
        {
            var arr = new int[] { 1, 2,3 };
            var rta = allSubSets(arr, 0);
            
            return "";
        }

    }
}
