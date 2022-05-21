using System.ComponentModel;

namespace Desktop.ViewModels.Common
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected BaseViewModel()
        {
            //
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler == null) 
                return;

            var e = new PropertyChangedEventArgs(propertyName);
            handler(this, e);
        }
    }
}