using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DirectorySystem.ViewModels
{
    public class HierarchyNodeViewModel
    {
        public HierarchyNodeViewModel()
        {
            Children = new List<HierarchyNodeViewModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public HierarchyNodeViewModel Parent { get; set; }
        public virtual ICollection<HierarchyNodeViewModel> Children { get; set; }
    }
}