
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises._2
{

    public class Node<T>
    {
        public T value { get; set; }
        public Node<T> next { get; set; }
    }

    class _2_6 : Exercise
    {

        public string result()
        {
            var elements = new string[] { "B","A","C","A","B" };

            var stack = buildStack<string>(elements);

            var linkedList = buildLinkedList<string>(elements);
            

            return isPalindrome<string>(linkedList,elements.Length,stack).ToString();
        }

        private Stack<T> buildStack<T>(T[] elements)
        {
            var stack = new Stack<T>();
            foreach (var value in elements)
            {
                stack.Push(value);
            }

            return stack;
        }

        public static Node<T> buildLinkedList<T>(T[] values)
        {
            var mainNode = new Node<T>();
            mainNode.value = values[0];
            var tempNode = mainNode;
            
            for (int i =1;i<values.Length;i++)
            {
                var tempNode2 = new Node<T>();
                tempNode2.value = values[i];

                tempNode.next = tempNode2;
                tempNode = tempNode2;
            }

            return mainNode;
        }


        public bool boolIsPalindromeRecursive<T>(Node<T> currentNode,int totalLenght,Stack<T> stack,int currentElement)
        {
            if (currentElement>= (int)(totalLenght/2))
            {
                return true;
            }
            
            var stackCurrentValue = stack.Pop();
            var isSameLetter = currentNode.value.ToString() == stackCurrentValue.ToString();

            var currentElementTemp = currentElement + 1;
            return boolIsPalindromeRecursive<T>(currentNode.next, totalLenght,stack, currentElementTemp) && isSameLetter;
        }

        public bool isPalindrome<T>(Node<T> mainNode,int totalLength,Stack<T> stack)
        {
            var currentElement = 0;
            return boolIsPalindromeRecursive<T>(mainNode, totalLength, stack,currentElement);
        }

        
    }
}
