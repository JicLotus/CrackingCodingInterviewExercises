using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises._1
{
    class _1_9 : Exercise
    {

        public string result()
        {

            var str1 = "waterbottle";
            var str2 = "erbottlewat";

            var str3 = str2 + str2;

            return str3.Contains(str1).ToString();
        }
    }
}
