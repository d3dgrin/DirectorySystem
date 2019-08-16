using DirectorySystem.Data.Interfaces;
using DirectorySystem.Data.Reposiroties;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectorySystem.Business.Modules
{
    public class ServiceModule : NinjectModule
    {
        private readonly string connectionString;

        public ServiceModule(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public override void Load()
        {
            Bind<IHierarchyNodeRepository>().To<HierarchyNodeRepository>().WithConstructorArgument(connectionString);
        }
    }
}
