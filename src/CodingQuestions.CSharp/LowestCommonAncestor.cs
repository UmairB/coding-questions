using System;

namespace CodingQuestions.CSharp
{
    /// <summary>
    /// See https://www.youtube.com/watch?v=NBcqBddFbZw
    /// </summary>
    public class LowestCommonAncestor
    {
        public void Run()
        {
            /* Constructed binary tree is
         10
       /   \
     7      30
   /  \    /
 4     8  16
/
2
*/
            Tree root = new Tree(10);
            root.Left = new Tree(7);
            root.Right = new Tree(30);
            root.Left.Left = new Tree(4);
            root.Left.Right = new Tree(8);
            root.Right.Left = new Tree(16);
            root.Left.Left.Left = new Tree(2);

            Tree p = root.Left.Left.Left; //2
            Tree q = root.Left.Right; // 8

            Tree LCA = FindLowestCommonAncestor(root, p, q);
            Console.WriteLine(LCA.Item);
        }

        public static Tree FindLowestCommonAncestor(Tree root, Tree p, Tree q)
        {
            if (root == null)
                return null;

            if (root == p || root == q)
                return root;

            Tree left = FindLowestCommonAncestor(root.Left, p, q);
            Tree right = FindLowestCommonAncestor(root.Right, p, q);

            if (left != null && right != null)
                return root;

            return left != null ? left : right;
        }
    }
    
    public class Tree
    {
        public int Item { get; }

        public Tree Left { get; set; }

        public Tree Right { get; set; }

        public Tree(int val)
        {
            Item = val;
            Left = null;
            Right = null;
        }
    }
}
