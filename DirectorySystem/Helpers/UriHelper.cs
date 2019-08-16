using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DirectorySystem.Helpers
{
    public class UriHelper
    {
        public static List<string> GetPartsOfUri(string uri)
        {
            return uri.Replace("%20", " ").Split('/').Skip(1).ToList();
        }
    }
}