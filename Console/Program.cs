using System;
using System.IO;
using PreciousGames.Verot.Morin.BusinessLayer.Managers;
using PreciousGames.Verot.Morin.ModelLayer.Entities;

namespace PreciousGames.Verot.Morin.Console
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo dataDirectoryInfo = new DirectoryInfo("../../../Infrastructure/ModelLayer/App_Data");
            AppDomain.CurrentDomain.SetData("DataDirectory", dataDirectoryInfo.FullName);

            try
            {
                Kind kind = new Kind()
                {
                    Name = "RPG",
                };

                Editor editor = new Editor()
                {
                    Name = "Bethesda",
                };

                Game game = new Game()
                {
                    Editor = editor,
                    Name = "The Elder Scrolls",
                    Description = "Super jeu monde ouvert",
                    Kind = kind,
                    ReleaseDate = DateTime.Now.AddYears(-5),
                };

                BusinessManager.Instance.AddGame(game);
                BusinessManager.Instance.SaveChanges();

                var list = BusinessManager.Instance.GetAllGames();

                System.Console.WriteLine(list.Count);
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
            }
        }
    }
}
