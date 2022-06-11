using System;
using System.Windows.Input;

namespace VerotMorin.PreciousGames.Desktop.ViewModels.Common
{
    /// <summary>
    /// Commande MVVM
    /// </summary>
    public class RelayCommand : ICommand
    {
        #region Variables

        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        #endregion

        #region Constructeurs

        public RelayCommand(Action execute)
            : this(execute, null)
        {
        }

        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");

            _execute = execute;
            _canExecute = canExecute;
        }

        #endregion

        #region Handler / Execution

        public void Execute(object parameter)
        {
            _execute();
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute?.Invoke() ?? true;
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (_canExecute != null)
                    CommandManager.RequerySuggested += value;
            }
            remove
            {
                if (_canExecute != null)
                    CommandManager.RequerySuggested -= value;
            }
        }

        #endregion
    }
}
