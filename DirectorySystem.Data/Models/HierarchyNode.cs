using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectorySystem.Data.Models
{
    public class HierarchyNode
    {
        public HierarchyNode()
        {
            Children = new List<HierarchyNode>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public HierarchyNode Parent { get; set; }
        public virtual ICollection<HierarchyNode> Children { get; set; }
    }
}
