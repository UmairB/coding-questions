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
            // Base case
            if (root == null)
                return null;

            // If either p or q matches with root's key, report
            // the presence by returning root (Note that if a key is
            // ancestor of other, then the ancestor key becomes LCA
            if (root == p || root == q)
                return root;

            // Look for keys in left and right subtrees
            Tree left = FindLowestCommonAncestor(root.Left, p, q);
            Tree right = FindLowestCommonAncestor(root.Right, p, q);

            // If both of the above calls return Non-NULL, then one key
            // is present in once subtree and other is present in other,
            // So this node is the LCA
            if (left != null && right != null)
                return root;

            // Otherwise check if left subtree or right subtree is LCA
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
