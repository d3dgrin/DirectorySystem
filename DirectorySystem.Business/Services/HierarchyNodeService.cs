using AutoMapper;
using DirectorySystem.Business.DTO;
using DirectorySystem.Business.Interfaces;
using DirectorySystem.Data.Interfaces;
using DirectorySystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectorySystem.Business.Services
{
    public class HierarchyNodeService : IHierarchyNodeService
    {
        private IHierarchyNodeRepository repo;

        public HierarchyNodeService(IHierarchyNodeRepository repo)
        {
            this.repo = repo;
        }

        public HierarchyNodeDTO GetRootNode()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<HierarchyNode, HierarchyNodeDTO>()).CreateMapper();
            return mapper.Map<HierarchyNode, HierarchyNodeDTO>(repo.GetRootNode());
        }

        public HierarchyNodeDTO GetNode(List<string> parts, List<HierarchyNodeDTO> nodes)
        {
            string part = parts.First();
            parts.RemoveAt(0);

            var node = nodes.FirstOrDefault(_ => _.Name.Equals(part));
            if (node != null && !parts.Any()) return node;

            if (node == null) return null;

            return GetNode(parts, node.Children.ToList());
        }
    }
}
