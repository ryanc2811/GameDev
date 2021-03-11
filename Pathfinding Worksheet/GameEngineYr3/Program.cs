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

            BinaryTree tree1 = new BinaryTree();
            BinaryTree tree2 = new BinaryTree();

            tree1.Root = new BinaryTreeNode("G");
            tree1.Root.LeftNode = new BinaryTreeNode("A");
            tree1.Root.LeftNode.LeftNode = new BinaryTreeNode("E");

            tree2.Root = new BinaryTreeNode("G");
            tree2.Root.LeftNode = new BinaryTreeNode("A");
            tree2.Root.LeftNode.LeftNode = new BinaryTreeNode("E");

            DepthFirstSearch depthFirstSearch = new DepthFirstSearch(tree1, "G");
            BreadthFirstSearch breadthFirstSearch = new BreadthFirstSearch(tree2, "A");
            //Console.WriteLine();
            using (var game = new GameEngine.Kernel())
                game.Run();
        }
    }
#endif
}
