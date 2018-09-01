using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises._8
{
    class _8_7 : Exercise
    {


        public string rotate(string text)
        {
            var tempText = text + text;
            return tempText.Substring(text.Length - 1, text.Length);
        }


        public List<string> saveAllPermutations(string text)
        {

            if (text.Length==1)
            {
                var list = new List<string>();
                list.Add(text);
                return list;
            }

            var tempText = text;
            var tempSolution = new List<string>();

            for (var i = 0; i < text.Length; i++)
            {
                var subString = tempText.Substring(1, text.Length - 1);

                var tempResult = saveAllPermutations(subString);

                foreach (var t in tempResult)
                {
                    var tempTextSolution = tempText[0] + t;
                    tempSolution.Add(tempTextSolution);
                }

                tempText = rotate(tempText);
            }

            return tempSolution;
        }

        public List<string> getTextPermutation(string text)
        {
            var result = saveAllPermutations(text);
            return result;
        }

        public string result()
        {
            string text = "abcd";
            var result = getTextPermutation(text);
            return string.Join(",", result.ToArray());
        }

    }
}
