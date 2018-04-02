using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises._8
{
    public class _8_9 : Exercise
    {


        private List<string> buildBasicsSolutions(int n)
        {
            List<string> validPairs = new List<string>();
            
            var firstPair = "";
            for (var i = 0; i < n; i++)
            {
                firstPair += "()";
            }
            validPairs.Add(firstPair);

            if (n > 1)
            {
                var scndPairs = "";
                for (var i = 0; i < n; i++)
                {
                    scndPairs = "(" + scndPairs + ")";
                }
                validPairs.Add(scndPairs);
            }

            if (n > 2)
            {


            }

            return validPairs;
        }


        public string validNPairParentesis(int n)
        {
            List<string> validPairs = new List<string>();
            validPairs = buildBasicsSolutions(n);
            
            if (n > 3)
            {

            }
            
            return string.Join(",", validPairs);
        }


        public string result()
        {
            var n = 3;
            return validNPairParentesis(n) + "\n";
        }

    }
}
