using System;
using PreciousGames.Verot.Morin.BusinessLayer.Managers;

namespace PreciousGames.Verot.Morin.Console
{
    internal static class Program
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
                System.Console.WriteLine(e);
            }
        }
    }
}
