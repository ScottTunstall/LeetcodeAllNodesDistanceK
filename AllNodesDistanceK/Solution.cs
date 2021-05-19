using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllNodesDistanceK
{
    public class Solution
    {
        private int[] _distances;
        private bool[] _visited;

        public IList<int> DistanceK(TreeNode root, TreeNode target, int k)
        {
            //DumpTree(root);

            if (k == 0)
                return new List<int>() {target.val};

            int nodeCount = 0;
            TreeNodeWithParent targetNodeWithParent = null;
            new TreeNodeWithParent(root, newTreeNodeWithParent =>
            {
                nodeCount ++;
                if (newTreeNodeWithParent.val == target.val)
                {
                    targetNodeWithParent = newTreeNodeWithParent;
                }
            });

            _distances = new int[nodeCount];
            _visited = new bool[nodeCount];

            _visited[targetNodeWithParent.val] = true;

            TraverseDownTree(targetNodeWithParent);
            TraverseUpTree(targetNodeWithParent);

            var toBeReturned = new List<int>();
            for (int i = 0; i < _distances.Length; i++)
            {
                if (_distances[i] == k)
                    toBeReturned.Add(i);
            }

            return toBeReturned;
        }



        // This DumpTree function lets me see what tree structures are being passed by leetcode's test cases,
        // so I can recreate them in code, for testing and debugging purposes.
        [Conditional("DEBUG")]
        private void DumpTree(TreeNode root)
        {
            DumpTreeRecursive(root);
        }

        private void DumpTreeRecursive(TreeNode node)
        {
            Console.WriteLine("Node:  " + (node !=null ? node.val.ToString() : "NULL"));
            if (node == null) return;

            Console.WriteLine("Left:  " + (node.left != null ? node.left.val.ToString() : "NULL"));
            Console.WriteLine("Right: " + (node.right != null ? node.right.val.ToString() : "NULL"));
            Console.WriteLine("");

            if (node.left != null)
                DumpTreeRecursive(node.left);

            if (node.right!=null)
                DumpTreeRecursive(node.right);

        }

        private void TraverseUpTree(TreeNodeWithParent targetNodeWithParent)
        {
            var currentDistance = 1;
            var parent = targetNodeWithParent.Parent;

            while (parent != null)
            {
                TraverseDownTreeRecursive(parent, currentDistance);
                currentDistance++;

                parent = parent.Parent;
            }
       
        }

        private void TraverseDownTree(TreeNodeWithParent startNode)
        {
            TraverseDownTreeRecursive(startNode, 0);
        }


        private void TraverseDownTreeRecursive(TreeNode treeNode, int currentDistance)
        {
            if (treeNode == null)
                return;

            if (!_visited[treeNode.val])
            {
                _distances[treeNode.val] = currentDistance;
                _visited[treeNode.val] = true;
            }

            TraverseDownTreeRecursive(treeNode.left, currentDistance + 1);
            TraverseDownTreeRecursive(treeNode.right, currentDistance + 1);
        }
        
    }
}
