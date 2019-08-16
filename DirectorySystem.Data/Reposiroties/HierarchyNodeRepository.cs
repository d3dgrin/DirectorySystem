using DirectorySystem.Data.Context;
using DirectorySystem.Data.Interfaces;
using DirectorySystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectorySystem.Data.Reposiroties
{
    public class HierarchyNodeRepository : IHierarchyNodeRepository
    {
        private readonly DirectorySystemContext db;

        public HierarchyNodeRepository(string connectionString)
        {
            db = new DirectorySystemContext(connectionString);
        }

        public HierarchyNode GetRootNode()
        {
            return db.HierarchyNodes.FirstOrDefault(_ => _.ParentId == null);
        }
    }
}
