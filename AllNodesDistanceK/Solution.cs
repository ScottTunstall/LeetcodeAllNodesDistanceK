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

        public IList<int> DistanceK(TreeNode root, TreeNode target, int k)
        {
            TreeNodeWithParent targetNodeWithParent = null;
            var asTree = new TreeNodeWithParent(root, newTreeNodeWithParent =>
            {
                if (newTreeNodeWithParent.val == target.val)
                {
                    targetNodeWithParent = newTreeNodeWithParent;
                }
            });

            var nodesToGetChildrenOf = new List<TreeNode>();
            nodesToGetChildrenOf.Add(targetNodeWithParent);
            nodesToGetChildrenOf.AddRange(GetAncestorsKLevelsAbove(targetNodeWithParent, k));

            var nodesWithinDistanceK = new List<TreeNode>();
            for (int i = 0; i < k && i< nodesToGetChildrenOf.Count; i++)
            {
                var ancestorNode = nodesToGetChildrenOf[i];
                var childNodes = GetDescendantNodesDistanceK(ancestorNode, k - i);
                nodesWithinDistanceK.AddRange(childNodes);
            }
            
            return nodesWithinDistanceK.Select(node => node.val).ToList();
        }


        private IList<TreeNode> GetAncestorsKLevelsAbove(TreeNodeWithParent targetNode, int k)
        {
            List<TreeNode> toBeReturned = new();
            
            var currentNode = targetNode.Parent;
            int count = 1; // parent node is one level above

            while (currentNode != null && count !=k)
            {
                toBeReturned.Add(currentNode);
                count++;
                currentNode = currentNode.Parent;
            }

            return toBeReturned;
        }



        /// Find child nodes that are distance K from treeNode startNode
        private IList<TreeNode> GetDescendantNodesDistanceK(TreeNode startNode, int k)
        {
            if (k == 0)
                return new List<TreeNode>() {startNode};

            if (k == 1)
                return new List<TreeNode>() {startNode.left, startNode.right};

            var level = 0;
            var childNodes = new List<TreeNode>();
            FindChildNodesRecursive(startNode, level, k, childNodes);
            return childNodes;
        }

        

        private void FindChildNodesRecursive(TreeNode node, int currLevel, int soughtLevel, List<TreeNode> output)
        {
            if (node == null)
                return;

            if (currLevel == soughtLevel)
            {
                output.Add(node);
                return;
            }

            FindChildNodesRecursive(node.left, currLevel+1, soughtLevel, output);
            FindChildNodesRecursive(node.right, currLevel+1, soughtLevel, output);
        }
    }
}
