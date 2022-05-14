using PreciousGame.Verot.Morin.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
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
                pg.Games.ToList();

            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
