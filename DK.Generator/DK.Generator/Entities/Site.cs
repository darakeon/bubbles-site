using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DK.Generator.Constants;

namespace DK.Generator.Entities
{
    class Site
    {
        public Site(String name, String background, String border)
        {
            Name = name;

            Url = String.Format(@"http://{0}", Name);
            
            var imagePath = String.Format(@"{0}.gif", Name);
            Image = new Image(imagePath);

            Background = background;
            Border = border;
        }


        public String Name { get; private set; }
        public String Url { get; private set; }
        public String Background { get; private set; }
        public String Border { get; private set; }

        public Image Image { get; private set; }

        

        public static IList<Site> GetAll()
        {
            return General.SiteNames.Select(
                sn => new Site(sn[0], sn[1], sn[2])
            ).ToList();
        }


    }
}
