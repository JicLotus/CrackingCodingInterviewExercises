using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises._4
{
    public static class TreeBulder
    {
        public static TNode<int> buildTree(int[] elements)
        {
            var root = new TNode<int>();
            root.value = elements[0];

            var actualNode = root;
            Queue queueNodes = new Queue();
            
            for (var i = 1; i < elements.Length; i++)
            {
                var node = new TNode<int>();
                node.value = elements[i];

                if (actualNode.left == null)
                {
                    actualNode.left = node;
                }
                else if (actualNode.right == null)
                {
                    actualNode.right = node;
                }
                else
                {
                    actualNode = (TNode<int>)queueNodes.Dequeue();
                    actualNode.left = node;
                }

                queueNodes.Enqueue(node);
            }

            return root;
        }
    }


    class _4_2 : Exercise
    {

        

        public string printTree(TNode<int> rootNode)
        {
            string result = "";
            var actualNode = rootNode;

            Queue queueNode = new Queue();

            while (actualNode != null)
            {
                result += actualNode.value + ",";
                
                queueNode.Enqueue(actualNode.left);
                queueNode.Enqueue(actualNode.right);

                actualNode = (TNode<int>)queueNode.Dequeue();
            }

            return result;
        }

        public string result()
        {
            var tree = TreeBulder.buildTree(new int[] {1,2,3,4,5});

            return printTree(tree);
        }

    }
}
