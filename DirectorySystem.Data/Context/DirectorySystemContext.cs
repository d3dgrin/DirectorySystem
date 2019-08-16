using DirectorySystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectorySystem.Data.Context
{
    public class DirectorySystemContext : DbContext
    {
        static DirectorySystemContext()
        {
            Database.SetInitializer(new DirectorySystemDbInitializer());
        }

        public DirectorySystemContext(string connectionString) : base(connectionString)
        {
        }

        public DbSet<HierarchyNode> HierarchyNodes { get; set; }
    }

    public class DirectorySystemDbInitializer : DropCreateDatabaseAlways<DirectorySystemContext>
    {
        protected override void Seed(DirectorySystemContext context)
        {
            var hierarchy = new List<HierarchyNode>
            {
                new HierarchyNode { Id = 1, Name = "Creating Digital Images" },
                new HierarchyNode { Id = 2, Name = "Resources", ParentId = 1 },
                new HierarchyNode { Id = 3, Name = "Evidence", ParentId = 1 },
                new HierarchyNode { Id = 4, Name = "Graphic Products", ParentId = 1 },
                new HierarchyNode { Id = 5, Name = "Primary Sources", ParentId = 2 },
                new HierarchyNode { Id = 6, Name = "Secondary Sources", ParentId = 2 },
                new HierarchyNode { Id = 7, Name = "Process", ParentId = 4 },
                new HierarchyNode { Id = 8, Name = "Final Products", ParentId = 4 }
            };

            context.HierarchyNodes.AddRange(hierarchy);
            context.SaveChanges();
        }
    }
}
