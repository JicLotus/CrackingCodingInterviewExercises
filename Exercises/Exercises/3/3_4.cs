using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises._3
{
    public class _3_4 : Exercise
    {

        public class queueWithStacks
        {
            stack s1;
            stack s2;

            public queueWithStacks()
            {
                s1 = new _3.stack();
                s2 = new _3.stack();
            }
            
            public int get()
            {
                int valueToReturn;
                node actualNode;
                actualNode = s1.pop();

                while (actualNode != null)
                {
                    s2.push(actualNode.value);
                    actualNode = s1.pop();
                }

                valueToReturn = s2.pop().value;
                
                actualNode = s2.pop();
                while (actualNode != null)
                {
                    s1.push(actualNode.value);
                    actualNode = s2.pop();
                }


                return valueToReturn;
            }

            public void put(int value)
            {
                s1.push(value);
            }

        
        }


        public string result()
        {
            var queue = new queueWithStacks();

            queue.put(1);
            queue.put(2);
            queue.put(3);

            return queue.get().ToString();
        }

    }
}
