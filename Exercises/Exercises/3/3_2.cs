using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises._3
{
    public class _3_2 : Exercise
    {

        

        public string result()
        {


            return "";
        }
        
    }

    public class stack
    {
        node top = null;
        stack minimunStack;
        public stack()
        {

        }


        //public node getMin()
        //{
            
        //}

        public void push(int value)
        {
            node _node = new _3.node();


            _node.value = value;
            _node.next = top;
            this.top = _node;
        }

        public node pop()
        {
            var actualTop = top;
            if (actualTop != null)
            {
                top = actualTop.next;
            }
            else
            {
                top = null;
            }

            return actualTop;
        }

    }


    public class node
    {
        public int value { get; set; }
        public node next { get; set; }
    }

}
