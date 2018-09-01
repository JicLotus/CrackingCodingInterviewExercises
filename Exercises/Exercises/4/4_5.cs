using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises._4
{
    class _4_5 : Exercise
    {

        public bool isBST(TNode<int> node, int maxValue, int minValue)
        {
            if (node == null)
            {
                return true;
            }
            var val = node.value;

            if (val > maxValue || val < minValue )
            {
                return false;
            }

            return isBST(node.left,node.value,minValue) && isBST(node.right,maxValue,node.value);
        }

        public string result()
        {

            var tree = TreeBulder.buildTree(new int[] { 1, 2,3,4 });
                
            return isBST(tree,int.MaxValue,int.MinValue).ToString();
        }

    }
}
