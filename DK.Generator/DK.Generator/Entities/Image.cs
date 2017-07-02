using System;
using System.IO;
using DK.Generator.Constants;

namespace DK.Generator.Entities
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
