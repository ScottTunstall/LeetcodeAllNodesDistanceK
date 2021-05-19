using System;

namespace AllNodesDistanceK
{
    class Program
    {
        static void Main(string[] args)
        {
            //var root = new TreeNode(3);
            //root.left = new TreeNode(5)
            //{
            //    left = new TreeNode(6),
            //    right = new TreeNode(2)
            //    {
            //        left = new TreeNode(7),
            //        right = new TreeNode(4)
            //    }
            //};

            //root.right = new TreeNode(1)
            //{
            //    left = new TreeNode(0),
            //    right = new TreeNode(8)
            //};

            //var target = root.left; //.left;

            var root = new TreeNode(0)
            {
                right = new TreeNode(1)
                {
                    right = new TreeNode(2)
                    {
                        right = new TreeNode(3)
                        {
                            left = new TreeNode(4)
                        }
                    }
                }
            };

            var target = root.right.right;

            var solution = new Solution();
            var result = solution.DistanceK(root, target, 2);
        }
    }
}
