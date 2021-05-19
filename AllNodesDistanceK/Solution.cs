using System;
using System.Collections;
using System.Collections.Generic;
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
            if (k == 0)
                return new List<int>() {target.val};

            int nodeCount = 0;
            TreeNodeWithParent targetNodeWithParent = null;
            var asTree = new TreeNodeWithParent(root, newTreeNodeWithParent =>
            {
                nodeCount ++;
                if (newTreeNodeWithParent.val == target.val)
                {
                    targetNodeWithParent = newTreeNodeWithParent;
                }
            });

            _distances = new int[nodeCount+1];
            _visited = new bool[nodeCount+1];

            _visited[targetNodeWithParent.val] = true;

            TraverseDownTree(targetNodeWithParent);
            TraverseUpTree(targetNodeWithParent);

            var toBeReturned = new List<int>();
            for (int i = 1; i < _distances.Length; i++)
            {
                if (_distances[i] == k)
                    toBeReturned.Add(i);
            }

            return toBeReturned;
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
