using GameEngine.PathFinding;
using System;

namespace GameEngineYr3
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            //BinaryTree tree1 = new BinaryTree();
            BinaryTree tree2 = new BinaryTree();
            BinaryTree tree3 = new BinaryTree();
            //tree1.Root = new BinaryTreeNode("G");
            //tree1.Root.LeftNode = new BinaryTreeNode("A");
            //tree1.Root.LeftNode.LeftNode = new BinaryTreeNode("E");

            //tree2.Root = new BinaryTreeNode("C");
            //tree2.Root.LeftNode = new BinaryTreeNode("B");
            //tree2.Root.RightNode = new BinaryTreeNode("D");
            //tree2.Root.RightNode.RightNode = new BinaryTreeNode("E");
            //tree2.Root.LeftNode.LeftNode = new BinaryTreeNode("A");

            tree3.Root = new BinaryTreeNode("N");
            tree3.Root.LeftNode = new BinaryTreeNode("M");
            tree3.Root.RightNode = new BinaryTreeNode("O");
            tree3.Root.LowerNode = new BinaryTreeNode("S");
            tree3.Root.UpperNode = new BinaryTreeNode("H");
            tree3.Root.RightNode.RightNode = new BinaryTreeNode("E");
            tree3.Root.LeftNode.LeftNode = new BinaryTreeNode("A");

            //DepthFirstSearch depthFirstSearch = new DepthFirstSearch(tree1, "G");
            //BreadthFirstSearch breadthFirstSearch = new BreadthFirstSearch(tree2, "A");
            Dijkstra dijkstra = new Dijkstra(tree3, "A");
            //Console.WriteLine();
            using (var game = new GameEngine.Kernel())
                game.Run();
        }
    }
#endif
}
