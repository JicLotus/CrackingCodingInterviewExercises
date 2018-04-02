using Exercises._2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises._3
{

    public class SetOfStacks<T> : Stack<T>
    {
        private Stack<Stack<T>> stacks;
        private int th { get; set; }

        public int StacksCount { get; set; }

        public SetOfStacks(int th)
        {
            stacks = new Stack<Stack<T>>();
            this.th = th;
        }

        public T pop()
        {
            var stack = stacks.Pop();
            if (stack.Count != 0)
            {
                stacks.Push(stack);
            }
            
            return stack.Pop();
        }

        public void push(T value)
        {
            var stack = stacks.Count ==0 ? null :stacks.Pop();

            if (stack == null ||stack.Count >= this.th)
            {
                stacks.Push(stack);
                stack = new Stack<T>();
                StacksCount++;
            }

            stack.Push(value);
            stacks.Push(stack);
        }


    }

    public class _3_3 : Exercise
    {
     
        public string result()
        {

            var specialStack = new SetOfStacks<int>(1);
            specialStack.push(1);
            specialStack.push(2);
            specialStack.push(3);
            specialStack.push(4);
            specialStack.push(5);


            return specialStack.StacksCount.ToString();
        }
        
           
    }
}
