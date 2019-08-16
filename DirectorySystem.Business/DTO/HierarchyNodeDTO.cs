using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectorySystem.Business.DTO
{
    public class HierarchyNodeDTO
    {
        public HierarchyNodeDTO()
        {
            Children = new List<HierarchyNodeDTO>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public HierarchyNodeDTO Parent { get; set; }
        public virtual ICollection<HierarchyNodeDTO> Children { get; set; }
    }
}
