using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises._4
{
    class _4_4 : Exercise
    {

        private int height(TNode<int> node)
        {
            if (node == null)
            {
                return 0;
            }

            var lH = 1 + height(node.left);
            var rH = 1 + height(node.right);


            var maxH = lH > rH ? lH : rH;

            return maxH;
        }

        private bool isBalanced(TNode<int> node)
        {
            if (node == null)
            {
                return true;
            }

            var lh = height(node.left);
            var lr = height(node.right);

            if (lh - lr > 1 || lr - lh > 1)
            {
                return false;
            }

            return isBalanced(node.left) && isBalanced(node.right);
        }


        public string result()
        {

            var tree = TreeBulder.buildTree(new int[] {1,2,3,4 });

            
            var n = new TNode<int>();
            n.value = 8;
            
            var n2 = new TNode<int>();
            n2.value = 8;

            tree.left.left.left = n;
            tree.left.left.left.left = n2;
            
            return isBalanced(tree).ToString();
        }

    }
}
