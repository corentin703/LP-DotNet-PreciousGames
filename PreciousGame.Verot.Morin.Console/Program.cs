using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PreciousGame.Verot.Morin.BusinessLayer.Managers;

namespace PreciousGame.Verot.Morin.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var list = Manager.Instance.GetAllGames();
                System.Console.WriteLine(list.Count);
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
