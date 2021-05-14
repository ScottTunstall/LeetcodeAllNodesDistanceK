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

        public IList<int> DistanceK(TreeNode root, TreeNode target, int K)
        {

            var childNodes  = FindChildren(target, K);
            return childNodes.Select(node => node.val).ToList();
        }


        /// Find child nodes that are distance K from treeNode startNode
        private List<TreeNode> FindChildren(TreeNode startNode, int k)
        {
            if (k == 0)
                return new List<TreeNode>() {startNode};

            if (k == 1)
                return new List<TreeNode>() {startNode.left, startNode.right};

            var level = 0;
            var childNodes = new List<TreeNode>();
            Recurse(startNode, level, k, childNodes);
            return childNodes;
        }

        private void Recurse(TreeNode node, int currLevel, int soughtLevel, List<TreeNode> output)
        {
            if (node == null)
                return;

            if (currLevel == soughtLevel)
            {
                output.Add(node);
                return;
            }

            Recurse(node.left, currLevel+1, soughtLevel, output);
            Recurse(node.right, currLevel+1, soughtLevel, output);
        }
    }
}
