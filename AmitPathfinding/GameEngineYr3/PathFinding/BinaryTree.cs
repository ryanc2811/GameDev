using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.PathFinding
{
    class BinaryTree
    {
        BinaryTreeNode root;

        public BinaryTreeNode Root { get=>root; set { root = value; } }

        public BinaryTree(BinaryTreeNode root=null)
        {
            //this.root = root;
            Clear();
        }

        private void Clear()
        {
            root = null;
        }
    }
}
