using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises._8
{
    public class _8_5 : Exercise
    {

        // So easy??? it's so weird
        int multiply(int num1,int num2)
        {
            if (num2==1)
            {
                return num1;
            }

            return num1 + multiply(num1, num2 - 1);
        }



        public string result()
        {
            return multiply(20,10).ToString();
        }

    }
}
