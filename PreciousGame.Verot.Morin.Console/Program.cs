using PreciousGame.Verot.Morin.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreciousGame.Verot.Morin.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PreciousGameContext pg = new PreciousGameContext();
                var list = pg.Editors.ToList();
                System.Console.WriteLine(list.Count);

            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
