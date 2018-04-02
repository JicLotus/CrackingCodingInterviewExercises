using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises._8
{
    public class _8_9 : Exercise
    {

        Dictionary<int, List<string>> solutions { get; set; }


        private List<string> buildConsecutiveSolutions(int n)
        {
            if (solutions.ContainsKey(n))
            {
                return solutions[n];
            }


            var beforeSolution = buildConsecutiveSolutions(n-1);
            var actualSolution = new List<string>();

            foreach(var tempSolution in beforeSolution)
            {
                
                for (var i =0;i<tempSolution.Length;i++)
                {
                    var tempString = tempSolution;
                    tempString = tempString.Insert(i + 1, "()");

                    if (!actualSolution.Contains(tempString))
                    {
                        actualSolution.Add(tempString);
                    }
                }
            }


            solutions[n] = actualSolution;

            return solutions[n];
        }

        private void buildSolution(int n)
        {
            solutions = new Dictionary<int, List<string>>();
            solutions[1] = new List<string>();
            solutions[1].Add("()");

            buildConsecutiveSolutions(n);
            
        }

        public string result()
        {
            var n = 3;
            buildSolution(n);
            
            return string.Join(",",solutions[n]);
        }

    }
}
