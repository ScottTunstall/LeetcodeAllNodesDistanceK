using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// ReSharper disable InconsistentNaming - because the class is defined by Leetcode, not I

namespace AllNodesDistanceK
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }

        public override string ToString()
        {
            return val.ToString();
        }
    }
}
