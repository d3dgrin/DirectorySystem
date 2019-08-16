﻿using DirectorySystem.Business.Interfaces;
using DirectorySystem.Business.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DirectorySystem.Modules
{
    public class HierarchyNodeModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IHierarchyNodeService>().To<HierarchyNodeService>();
        }
    }
}