using System.Windows;
using VerotMorin.PreciousGames.Desktop.ViewModels;

namespace VerotMorin.PreciousGames.Desktop.Views
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class AddGameWindow : Window
    {
        /*public AddGameWindow()
        {
            InitializeComponent();
        }*/

        public AddGameWindow(AddGameViewModel addGameViewModel)
        {
            DataContext = addGameViewModel;
            InitializeComponent();
        }
    }
}
