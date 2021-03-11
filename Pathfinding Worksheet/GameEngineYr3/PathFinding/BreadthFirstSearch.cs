using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.PathFinding
{
    class BreadthFirstSearch 
    {
    Node top = null;

    Queue<Node> nodes = new Queue<Node>();
    public BreadthFirstSearch(BinaryTree binaryTree, string value)
    {
        nodes = new Queue<Node>();
        nodes.Enqueue(binaryTree.Root);
        top = nodes.Peek();


        while (nodes.Count > 0)
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
                            nodes.Enqueue(top.Neighbours[i]);
                        }
                    }
                }
            }
            if (top.Visited)
            {
                nodes.Dequeue();
                Console.WriteLine("Node Popped");
            }
        }


    }
}
}
