using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.PathFinding
{
    class DepthFirstSearch
    {
        Node top = null;

        Stack<Node> nodes = new Stack<Node>();
        public DepthFirstSearch(BinaryTree binaryTree, string value)
        {
            nodes = new Stack<Node>();
            nodes.Push(binaryTree.Root);
            top = nodes.Peek();
            
            
            while (nodes.Count>0)
            {
                if (!top.Visited)
                {
                    Console.WriteLine(top.Data + " Visited");
                    top.Visited = true;
                    if (top.Neighbours != null)
                    {
                        for (int i = 0; i < top.Neighbours.Count; i++)
                        {
                            if (top.Neighbours[i].Data != "")
                            {
                                nodes.Push(top.Neighbours[i]);
                            }
                        }
                    }
                }
                if (top.Visited)
                {
                    nodes.Pop();
                    Console.WriteLine("Node Popped");
                }
            }

            
        }
    }
}
