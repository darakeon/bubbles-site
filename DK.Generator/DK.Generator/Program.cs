using DK.Generator.Entities;
using System;

namespace DK.Generator
{
    class Program
    {
        public static void Main()
        {
            var sites = Site.GetAll();

            var error = Tests.TestAll(sites);

            if (!error)
            {
                new Page(sites).SaveFiles();
            }

            Console.Write("Finished!");

            Console.ReadLine();

        }


        
    }
}
