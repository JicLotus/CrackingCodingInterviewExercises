using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises._4
{
    class _4_8 : Exercise
    {

        public int dist(TNode<int> node,int value)
        {
            if (node == null)
            {
                return 0;
            }

            if (node.value == value)
            {
                return 1;
            }

            var dist1 = dist(node.left,value);
            var dist2 = dist(node.right,value);

            if (dist1 > 0) dist1=dist1 + 1;
            if (dist2 > 0) dist2=dist2 + 1;

            return dist1 > dist2 ? dist1 : dist2;
        }

        private TNode<int> firstCommonAncestor(TNode<int> node,TNode<int> mainNode,int value1, int value2,int dist1,int dist2)
        {
            if (node == null)
            {
                return null;
            }

            var distValue1 = dist(node,value1);
            var distValue2 = dist(node,value2);

            if (distValue1 > dist1 && distValue2 > dist2)
            {
                return null;
            }
            
            if (distValue1>dist1 && distValue2 < dist2 || distValue1 < dist1 && distValue2 > dist2 || distValue2==0 || distValue1==0)
            {
                return mainNode;
            }
            
            var node1=firstCommonAncestor(node.left,node,value1,value2,distValue1,distValue2);
            var node2=firstCommonAncestor(node.right,node, value1, value2, distValue1,distValue2);

            if (node1 != null)
            {
                return node1;
            }
            if (node2 != null)
            {
                return node2;
            }

            return null;
        }


        public string result()
        {
            var tree = TreeBulder.buildTree(new int[] { 1,8,4,14,100,1,1,5 });
            var value1 = 5;
            var value2 = 100;

            return firstCommonAncestor(tree,tree,value1,value2,int.MaxValue,int.MaxValue).value.ToString();
        }

    }
}
