using DirectorySystem.Business.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectorySystem.Business.Interfaces
{
    public interface IHierarchyNodeService
    {
        HierarchyNodeDTO GetRootNode();
        HierarchyNodeDTO GetNode(List<string> parts, List<HierarchyNodeDTO> nodes);
    }
}
