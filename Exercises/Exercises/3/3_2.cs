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

            minStack mins = new minStack();
            mins.push(1);
            mins.push(-1);
            mins.push(3);
            mins.push(300);
            mins.push(12831);
            mins.push(4);
            mins.push(0);
            mins.push(-12313);
            mins.push(545);

            return mins.minValue().ToString();
        }
        
    }


    public class minStack : stack
    {
        stack minsValues { get; set; }

        public minStack() : base()
        {
            minsValues = new stack();
        }

        public int minValue()
        {
            return minsValues.top.value;
        }

        public override node pop()
        {
            var valueToPop = base.pop();

            if (minsValues.top != null)
            {
                if (valueToPop.value == minsValues.top.value)
                {
                    minsValues.pop();
                }
            }
            
            return valueToPop;
        }

        public override void push(int value)
        {
            base.push(value);

            if (minsValues.top != null)
            {
                if (value < minsValues.top.value)
                {
                    minsValues.push(value);
                }
            }
            else
            {
                minsValues.push(value);
            }
        }


    }

    public class stack
    {
        public node top { get; set; }
        
        public stack()
        {
            top = null;
        }
        
        public virtual void push(int value)
        {
            node _node = new _3.node();
            
            _node.value = value;
            _node.next = top;
            this.top = _node;
        }

        public virtual node pop()
        {
            var actualTop = top;
            if (actualTop != null)
            {
                top = actualTop.next;
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
