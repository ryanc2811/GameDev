using GameEngine.MoreCollections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.PathFinding
{
    class Dijkstra
    {
        Node top = null;

        //MinHeap<Node> frontier;
        PriorityQueue<Node> frontier;

        Dictionary<string, Node> cameFrom = new Dictionary<string, Node>();
        Dictionary<string, int> costSoFar = new Dictionary<string, int>();


        public Dijkstra(BinaryTree binaryTree, string goal)
        {
            frontier = new PriorityQueue<Node>();
            //Add start to queue
            frontier.Enqueue(binaryTree.Root,0);
            //Add start to came from dictionary
            cameFrom.Add(binaryTree.Root.Data, null);
            costSoFar.Add(binaryTree.Root.Data, 0);

            //Console.WriteLine("Came From " + cameFrom[binaryTree.Root.Data].Data);

            //While frontier not empty
            while (!frontier.IsEmpty())
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
                                int newCost = costSoFar[top.Data]+ top.Neighbours[i].Cost;
                                //if the next node has not been visited
                                if (!cameFrom.ContainsKey(top.Neighbours[i].Data)||newCost<costSoFar[top.Neighbours[i].Data])
                                {
                                    costSoFar[top.Neighbours[i].Data] = newCost;
                                    int priority = newCost;
                                    //add next node to queue
                                    frontier.Enqueue(top.Neighbours[i],priority);
                                    //Add next node to came from dictionary
                                    cameFrom[top.Neighbours[i].Data]= top;
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
