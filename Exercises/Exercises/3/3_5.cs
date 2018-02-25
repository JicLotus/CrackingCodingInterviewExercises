using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises._3
{
    public class _3_5 : Exercise
    {

        public void sortStack(stack s1)
        {
            stack s2 = new stack();
            node tempNode;
            int minValue = int.MaxValue;

            while (s1.top != null)
            {
                
                tempNode = s1.pop();
                
                while (tempNode != null)
                {
                    if (tempNode.value < minValue)
                    {
                        minValue = tempNode.value;
                    }
                    s2.push(tempNode.value);
                    tempNode = s1.pop();
                }

                tempNode = s2.pop();

                while (tempNode != null)
                {
                    if (tempNode.value != minValue)
                    {
                        s1.push(tempNode.value);
                    }
                    
                    tempNode = s2.pop();

                    if (tempNode != null)
                    {
                        if (tempNode.value < minValue)
                        {
                            s2.push(tempNode.value);
                            tempNode = null;
                        }
                    }
                }

                s2.push(minValue);


                minValue = int.MaxValue;
            }
            

            //Push all s2 values to s1
            tempNode = s2.pop();
            while (tempNode != null)
            {
                s1.push(tempNode.value);
                tempNode = s2.pop();
            }
            

        }
        

        public string result()
        {
            stack s1 = new stack();
            s1.push(3);
            s1.push(2);
            s1.push(6);
            s1.push(8);
            s1.push(1);

            sortStack(s1);

            string rlt = "";

            node tempNode = s1.pop();
            while (tempNode!=null)
            {
                rlt += tempNode.value.ToString() +",";
                tempNode = s1.pop();
            }

            return rlt;
        }

    }
}
