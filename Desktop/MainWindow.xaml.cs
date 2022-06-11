using System.Windows;
using VerotMorin.PreciousGames.Desktop.ViewModels;

namespace VerotMorin.PreciousGames.Desktop
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new HomeViewModel();
        }
    }
}
