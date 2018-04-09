using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises._4
{
    class _4_10 : Exercise
    {

        TNode<int> buildTree()
        {
            var root = new TNode<int>();
            root.value = 50;

            var l1 = new TNode<int>();
            l1.value = 20;

            var r1 = new TNode<int>();
            r1.value = 60;

            root.left = l1;
            root.right = r1;


            var l21 = new TNode<int>();
            l21.value = 10;

            var r21 = new TNode<int>();
            r21.value = 25;


            l1.right = r21;
            l1.left = l21;


            var l22 = new TNode<int>();
            l22.value = 70;


            r1.right = l22;



            return root;
        }


        TNode<int> buildTree2()
        {
            var root = new TNode<int>();
            root.value = 20;

            var l1 = new TNode<int>();
            l1.value = 10;

            var r1 = new TNode<int>();
            r1.value = 25;

            root.left = l1;
            root.right = r1;
            
            return root;
        }


        public TNode<int> searchNodeValue(TNode<int> node, int value)
        {
            if (node.value == value)
            {
                return node;
            }else if(node.value > value)
            {
                return searchNodeValue(node.left,value);
            }else
            {
                return searchNodeValue(node.right, value);
            }
        }

        public bool haveSameTree(TNode<int> node1, TNode<int> node2)
        {
            if (node1 == null && node2 == null)
            {
                return true;
            }
            
            bool r1;
            bool r2;

            if (node1.value == node2.value)
            {
                r1= haveSameTree(node1.left, node2.left);
                r2= haveSameTree(node1.right, node2.right);
            }else
            {
                return false;
            }
            
            return  r1 && r2;
        }


        public string result()
        {
            var t1 = buildTree();
            var t2 = buildTree2();

            var interT1secNode =  searchNodeValue(t1,t2.value);
            
            return haveSameTree(interT1secNode,t2).ToString();
        }

    }
}
