using DirectorySystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectorySystem.Data.Interfaces
{
    public interface IHierarchyNodeRepository
    {
        HierarchyNode GetRootNode();
    }
}
