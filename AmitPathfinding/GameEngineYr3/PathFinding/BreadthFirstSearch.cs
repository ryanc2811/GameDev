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

        Queue<Node> frontier = new Queue<Node>();
        Dictionary<string,Node> cameFrom = new Dictionary<string, Node>();

        public BreadthFirstSearch(BinaryTree binaryTree, string goal)
        {
            frontier = new Queue<Node>();
            //Add start to queue
            frontier.Enqueue(binaryTree.Root);
            //Add start to came from dictionary
            cameFrom.Add(binaryTree.Root.Data,binaryTree.Root);
            Console.WriteLine("Came From " + cameFrom[binaryTree.Root.Data].Data);
            //While frontier not empty
            while (frontier.Count > 0)
            {
                //current node is top of queue
                top = frontier.Peek();
                //if top node hasnt been visited
                if (!top.Visited)
                {
                    Console.WriteLine(top.Data + " Visited");
                    top.Visited = true;

                    //if reached goal, break out of loop
                    if (top.Data == goal)
                        break;

                    if (top.Neighbours != null)
                    {
                        for (int i = 0; i < top.Neighbours.Count; i++)
                        {
                            if (top.Neighbours[i].Data != "")
                            {
                                //if the next node has not been visited
                                if (!cameFrom.ContainsKey(top.Neighbours[i].Data))
                                {
                                    //add next node to queue
                                    frontier.Enqueue(top.Neighbours[i]);
                                    //Add next node to came from dictionary
                                    cameFrom.Add(top.Neighbours[i].Data, top.Neighbours[i]);
                                    Console.WriteLine("Came From " + cameFrom[top.Neighbours[i].Data].Data);
                                }
                            }
                        }
                    }
                }
                //if current node has been visted, then remove it from queue
                if (top.Visited)
                {
                    frontier.Dequeue();
                    Console.WriteLine("Node Popped");
                }
            }
        }
    }
}
