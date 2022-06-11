using System;
using System.IO;
using System.Windows;

namespace VerotMorin.PreciousGames.Desktop
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Localise le fichier de base de données
            DirectoryInfo dataDirectoryInfo = new DirectoryInfo("../../../Infrastructure/ModelLayer/App_Data");
            AppDomain.CurrentDomain.SetData("DataDirectory", dataDirectoryInfo.FullName);
        }
    }
}
