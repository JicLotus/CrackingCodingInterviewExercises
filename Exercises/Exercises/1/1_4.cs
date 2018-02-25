using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises._1
{

    
    class _1_4 : Exercise
    {
        
        public string result()
        {
            var str = "Tact Coa";
            //var str = "Hola";
            var pp = new palindromePermutation(str);
            
            return pp.isPermutationPalindrome().ToString();
        }
    }

    public class palindromePermutation
    {
        string str { get; set; }
        public palindromePermutation(string str)
        {
            this.str = str;
        }


        //Is not used
        public bool isPalindrome(string _str)
        {
            var tempStr = _str.Replace(" ", "");
            var len = tempStr.Length;

            if ((len %  2) == 0)
            {
                return false;
            }

            for (var i =0;i<len/2;i++)
            {
                var char1 = tempStr[i];
                var char2 = tempStr[len-1-i];
                if (char1 != char2)
                {
                    return false;
                }
            }

            return true;
        }

        public bool isPermutationPalindrome()
        {
            Dictionary<char, int> chars = new Dictionary<char, int>();
            char[] tempArr = this.str.Replace(" ", "").ToLower().ToArray();

            for (var i =0;i<tempArr.Length;i++)
            {
                if (chars.ContainsKey(tempArr[i]))
                {
                    chars[tempArr[i]]++;
                }
                else
                {
                    chars[tempArr[i]] = 1;
                }
            }

            if (chars.Select(x=>x.Value).Where(k=>k==1).ToArray().Length != 1)
            {
                return false;
            }

            return true;
        }
        

    }

}
