using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using DA.Generator.Entities;

namespace DA.Generator
{
    class Tests
    {
        public static bool TestAll(IEnumerable<Site> sites)
        {
            var errors = false;

            foreach (var site in sites)
            {
                Console.WriteLine("Testing {0}", site.Name);

                var error = testImage(site)
                         || testUrl(site);

                if (!error)
                    Console.WriteLine("OK");

                errors |= error;

                Console.WriteLine();
            }

            return errors;
        }


        private static bool testImage(Site site)
        {
            if (!File.Exists(site.Image.FullPath))
            {
                Console.WriteLine("Not found: {0}", site.Image.FullPath);
                return true;
            }

            return false;
        }

        private static bool testUrl(Site site)
        {
            var request = WebRequest.Create(site.Url);

            try
            {
                request.GetResponse();
            }
            catch (Exception)
            {
                Console.WriteLine("Not found: {0}", site.Url);
                return true;
            }

            return false;
        }
    
    }


    

}
