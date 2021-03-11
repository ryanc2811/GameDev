using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.PathFinding
{
    class BinaryTreeNode:Node
    {
        public BinaryTreeNode LeftNode
        {
            get
            {
                if (Neighbours == null)
                    return null;
                else
                    return Neighbours[0] as BinaryTreeNode;
            }
            set
            {
                if (Neighbours == null)
                {
                    IList<Node> nodes = new List<Node>();
                    Neighbours = nodes;
                    Node left = new BinaryTreeNode();
                    Node right = new BinaryTreeNode();
                    Neighbours.Add(left);
                    Neighbours.Add(right);
                }
                Neighbours[0] = value;
            }
        }
        public BinaryTreeNode RightNode 
        { 
            get 
            { 
                if (Neighbours == null) 
                    return null; 
                else
                    return Neighbours[1] as BinaryTreeNode;
            }
            set
            {
                if (Neighbours == null)
                {
                    IList<Node> nodes = new List<Node>();
                    Neighbours = nodes;
                    Node leftNode = new BinaryTreeNode();
                    Node rightNode = new BinaryTreeNode();
                    Neighbours.Add(leftNode);
                    Neighbours.Add(rightNode);
                }
               Neighbours[1] = value;
            }
        }
        public BinaryTreeNode()
        {

        }
        public BinaryTreeNode(string data):base(data,null)
        {
            //Data = data;
        }
        public BinaryTreeNode(string data, BinaryTreeNode left, BinaryTreeNode right)
        {
            Data = data;
            IList<Node> children = new List<Node>();
            children.Add(left);
            children.Add(right);
            Neighbours = children;
        }
    }
}
