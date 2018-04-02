using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises._2
{
    class _2_7 : Exercise
    {

        public string result()
        {
            var elements = new string[] { "A", "B", "D"};

            var firstLinkedList = _2_6.buildLinkedList<string>(elements);
            var secondLinkedList = new Node<string>();
            secondLinkedList.value = "C";
            secondLinkedList.next = getNodeReferenceFromList<string>(firstLinkedList,"D");
            
            var firstStack = buildStackFromList<string>(firstLinkedList);
            var secondStack = buildStackFromList<string>(secondLinkedList);
            
            return getIntersectionNode<string>(firstStack,secondStack).value;
        }

        private Node<T> getNodeReferenceFromList<T>(Node<T> list,T reference)
        {
            Node<T> tempNode = list;

            while (tempNode != null)
            {
                if (tempNode.value.ToString() == reference.ToString())
                {
                    break;
                }
                tempNode = tempNode.next;
            }

            return tempNode;
        }

        private Stack<Node<T>> buildStackFromList<T>(Node<T> list)
        {
            var s = new Stack<Node<T>>();

            var tempNode = list;
            while (tempNode != null)
            {
                s.Push(tempNode);
                tempNode = tempNode.next;   
            }

            return s;
        }

        private Node<T> getIntersectionNode<T>(Stack<Node<T>> s1, Stack<Node<T>> s2)
        {
            Node<T> intersectionNode = null;

            var tempS1Node = s1.Pop();
            var tempS2Node = s2.Pop();

            while (tempS1Node!=null && tempS2Node!=null)
            {
                if (tempS1Node!= tempS2Node)
                {
                    intersectionNode = tempS1Node.next;
                    break;
                }

                tempS1Node = s1.Pop();
                tempS2Node = s2.Pop();
            }

            return intersectionNode;
        }
        
    }
}
