using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DirectorySystem.ViewModels
{
    public class DirectorySystemIndexViewModel
    {
        public string Url { get; set; }
        public HierarchyNodeViewModel Node { get; set; }
        public List<string> Errors { get; set; }
    }
}