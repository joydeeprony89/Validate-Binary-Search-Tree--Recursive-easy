using System;

namespace Validate_Binary_Search_Tree__Recursive_easy
{
  class Program
  {
    static void Main(string[] args)
    {
      TreeNode node = new TreeNode(-2147483648);
      node.left = null;
      node.right = new TreeNode(2147483647);
      //node.left.left = new TreeNode(5);
      //node.left.right = new TreeNode(9);
      //node.right.left = new TreeNode(8);
      //node.right.right = new TreeNode(14);
      Solution s = new Solution();
      s.IsValidBST(node);
    }
  }

  public class TreeNode
  {
    public int val { get; set; }
    public TreeNode left { get; set; }
    public TreeNode right { get; set; }
    public TreeNode(int val)
    {
      this.val = val;
    }
  }

  public class Solution
  {
    public bool IsValidBST(TreeNode root)
    {
      // The idea is here will set a range for each node, in bw which range root value can exist, else its invalid.
      // We are setting the initial range for the root node bw -long.inf to long.inf,  -INF < root.val < INF
      // Now recursivly will traverse the left nodes first, for each left node, condition - -INF < left.val < root.val. we need to update the only right range
      // when traversing left tree.
      // Now recursivly will traverse the right nodes , for each right node, condition - root.val < left.val < INF. we need to update the only left range
      // when traversing left tree.
      bool Valid(TreeNode root, long left, long right)
      {
        // if root is null, its a BST
        if (root == null) return true;

        // if root value is less than/eq to left range OR bigger/eq than right range, its INVALID.
        if (root.val <= left || root.val >= right) return false;

        var isLeftValid = Valid(root.left, left, root.val);
        var isRightValid = Valid(root.right, root.val, right);

        return isLeftValid && isRightValid;
      }

      return Valid(root, long.MinValue, long.MaxValue);
    }
  }
}
