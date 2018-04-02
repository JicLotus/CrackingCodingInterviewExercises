using Exercises._2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises._4
{

    public class GNode<T>
    {
        public List<GNode<T>> nodes;
        public bool visited { get; set; }
        public T value { get; set; }
    }
    

    class _4_1 :Exercise
    {

        public static GNode<T> BFS<T>(GNode<T> graph, T value)
        {
            var s1 = new Queue<GNode<T>>();
            s1.Enqueue(graph);

            var tempNode = s1.Dequeue();

            while (tempNode != null)
            {
                
                if (tempNode.value.ToString() == value.ToString())
                {
                    return tempNode;
                }

                foreach (var node in tempNode.nodes)
                {
                    tempNode.visited = true;
                    s1.Enqueue(node);
                }

                try
                {
                    tempNode = s1.Dequeue();
                }
                catch (Exception)
                {
                    tempNode = null;
                }
            }
            return null;
        }

        private GNode<string> buildGraph()
        {
            var elements = new string[] { "A", "B","C","D","H"};

            var graph = new GNode<string>();
            graph.nodes = new List<GNode<string>>();
            graph.value = elements[0];
            graph.visited = false;

            var tempNode = graph;

            for (int i =0;i<elements.Length;i++)
            {
                var gNode = new GNode<string>();
                gNode.nodes = new List<GNode<string>>();
                gNode.value = elements[i];
                gNode.visited = false;

                tempNode.nodes.Add(gNode);

                tempNode = gNode;
            }
            
            return graph;
        }


        public string result()
        {
            var graph = buildGraph();

            var node1 = BFS<string>(graph,"B");
            var node2 = BFS<string>(node1,"H");

            return node2 != null? "Have a path\n" : "Does not have a path\n";
        }

    }
}
