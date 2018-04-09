using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises._4 
{
    class _4_12 : Exercise
    {


        TNode<int> buildTree()
        {
            var root = new TNode<int>();
            root.value = 10;

            var l1 = new TNode<int>();
            l1.value = 5;

            var r1 = new TNode<int>();
            r1.value = 8;

            root.left = l1;
            root.right = r1;
            
            var l21 = new TNode<int>();
            l21.value = 2;
            
            l1.left = l21;


            var l31 = new TNode<int>();
            l31.value = 7;

            r1.left = l31;

            return root;
        }

        private int countPathWithSum(TNode<int> node, int value,int initialValue)
        {
            if (node == null)
            {
                return 0;
            }
            
            var actualValue = node.value;
            var diff = value - actualValue;
            
            var countLeft = 0;
            var countRight = 0;

            var returnedValue = diff == 0 ? 1 : 0;

            if (diff < 0)
            {
                countLeft = countPathWithSum(node.left, value, initialValue);
                countRight = countPathWithSum(node.right, value, initialValue);
            }
            else
            {
                if (returnedValue == 1) diff = initialValue;

                countLeft = countPathWithSum(node.left, diff, initialValue);
                countRight = countPathWithSum(node.right, diff, initialValue);
            }
            
            return returnedValue + countLeft + countRight;
        }


        public string result()
        {
            var tree = buildTree();
            
            return countPathWithSum(tree,7,7).ToString();
        }

    }
}
