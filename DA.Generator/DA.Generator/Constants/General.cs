using System;
using System.IO;

namespace DA.Generator.Constants
{
    class General
    {
        public static readonly String[][] SiteNames = new[]
        {
            new[] {"dontflymoney.com", "FDD", "900"},
            new[] {"meak-stories.com", "DDF", "009"},
            new[] {"eh-difihcil.blogspot.com.br", "DFD", "090"},
            
        };

        public static readonly String SitePath
            = Path.GetFullPath(@"..\..\..\..\Site");

        public const String BodyColor = "000";

    }
}
