using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllNodesDistanceK
{
    public class TreeNodeWithParent: TreeNode
    {
        //
        public TreeNodeWithParent(TreeNode rootNodeToWrap, Action<TreeNodeWithParent> postConstructionAction) : this(null, rootNodeToWrap, postConstructionAction)
        {
        }

        public TreeNodeWithParent(TreeNodeWithParent parentNode, TreeNode toWrap, Action<TreeNodeWithParent> postConstructionAction) : base(toWrap.val)
        {
            Parent = parentNode;
            left = toWrap.left != null ? new TreeNodeWithParent(this, toWrap.left, postConstructionAction) : null;
            right = toWrap.right != null ? new TreeNodeWithParent(this, toWrap.right, postConstructionAction) : null;
            
            postConstructionAction?.Invoke(this);
        }

        public TreeNodeWithParent Parent { get; }
    }
}
