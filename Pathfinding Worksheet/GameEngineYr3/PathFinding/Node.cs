﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.PathFinding
{
    class Node
    {
        private string data="";
        private IList<Node> neighbours;
        private bool visited=false;

        public string Data { get { return data; } protected set { data = value; } }
        public IList<Node> Neighbours{get { return neighbours; } protected set { neighbours = value; } }
        public bool Visited { get { return visited; } set { visited = value; } }

        public Node(string data, IList<Node> neighbours)
        {
            this.data = data;
            this.neighbours = neighbours;
        }

        public Node(string data): this(data, null)
        {
            this.data = data;
        }

        public Node()
        {
            
        }
    }
}
