using Desktop.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Desktop.Views
{
    /// <summary>
    /// Logique d'interaction pour GameList.xaml
    /// </summary>
    public partial class GameList : UserControl
    {
        private RelayCommand _actionOpenAddWindow;
        public GameList()
        {
            InitializeComponent();
        }

        public void AddNewGame()
        {
            AddGameWindow addGameWindow = new AddGameWindow();
            addGameWindow.Show();

        }

        public ICommand AddNewGameCommande
        {
            get
            {
                if (_actionOpenAddWindow == null)
                    _actionOpenAddWindow = new RelayCommand(AddNewGame);

                return _actionOpenAddWindow;
            }

        }
    }
}
