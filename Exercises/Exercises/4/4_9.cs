using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises._4
{

    public class TNode<T>
    {
        public TNode<T> left { get; set; }
        public TNode<T> right { get; set; }
        public T value { get; set; }
    }

    class _4_9 : Exercise
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

        public List<List<int>> getTreeCombinatory(TNode<int> node)
        {
            if (node == null || (node.left == null && node.right == null))
            {
                return null;
            }

            var tempStackResult = new List<List<int>>();

            int l;
            int r;
            int middle = node.value;

            List<int> tempResult = new List<int>();

            tempResult.Add(middle);

            if (node.left != null)
            {
                l = node.left.value;
                tempResult.Add(l);
            }

            if (node.right != null)
            {
                r = node.right.value;
                tempResult.Add(r);
            }

            tempStackResult.Add(tempResult);


            if (node.right != null && node.left != null)
            {
                tempResult = new List<int>();

                tempResult.Add(middle);

                r = node.right.value;
                tempResult.Add(r);

                l = node.left.value;
                tempResult.Add(l);

                tempStackResult.Add(tempResult);
            }
            
            var leftCall = getTreeCombinatory(node.left);
            var rightCall = getTreeCombinatory(node.right);

            var mergedRL = mergeLRSolution(leftCall, rightCall);

            List<List<int>> finalStackResult = new List<List<int>>();

            foreach (var stackResult in tempStackResult)
            {
                if (mergedRL != null)
                {
                    addSolutionElementsToArray(stackResult, mergedRL, finalStackResult);
                }
            }

            if (finalStackResult.Count > 0)
            {
                tempStackResult = finalStackResult;
            }
            

            return tempStackResult;
        }


        public List<List<int>> mergeLRSolution(List<List<int>> leftCall , List<List<int>> rightCall)
        {
            var mergedRL = new List<List<int>>();

            if (leftCall != null && rightCall != null)
            {
                foreach (var l1 in leftCall)
                {
                    foreach (var r1 in rightCall)
                    {
                        var tempArray = new List<int>();
                        tempArray.AddRange(l1);
                        tempArray.AddRange(r1);
                        mergedRL.Add(tempArray);
                    }
                }
            }
            else
            {
                if (leftCall != null)
                {
                    mergedRL = leftCall;
                }
                else
                {
                    mergedRL = rightCall;
                }
            }

            return mergedRL;
        }

        public void addSolutionElementsToArray(List<int> array,List<List<int>> solution, List<List<int>> partialSolution)
        {
            foreach (var element in solution)
            {
                var tempArray = new List<int>();
                tempArray.AddRange(array);
                for (var i = 0; i < element.Count; i++)
                {
                    if (!array.Contains(element[i]))
                    {
                        tempArray.Add(element[i]);
                    }
                }
                partialSolution.Add(tempArray);
            }

        }


        public string result()
        {
            var tree = buildTree();

            var solution = getTreeCombinatory(tree);

            foreach (var sol in solution)
            {
                Console.WriteLine(string.Join(",", sol));
            }

            return "";
        }

    }
}
