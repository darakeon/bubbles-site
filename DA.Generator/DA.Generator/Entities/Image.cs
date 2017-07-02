using System;
using System.IO;
using DA.Generator.Constants;

namespace DA.Generator.Entities
{
    class Image
    {
        public Image(String imagePath)
        {
            LocalPath = imagePath;
            FullPath = Path.Combine(General.SitePath, LocalPath);
        }

        public String FullPath { get; private set; }
        public String LocalPath { get; private set; }


    }
}
