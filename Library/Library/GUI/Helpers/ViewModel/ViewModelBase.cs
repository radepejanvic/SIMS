using System.ComponentModel;
using System.Windows;
using Library.EventArgument;

namespace Library.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected void ExecutionCompleted(object? sender, ExecutionCompletedEventArgs e)
        {
            if (e.IsSuccessfull) { MessageBox.Show(e.Message, "Info", MessageBoxButton.OK, MessageBoxImage.Information); }
            else { MessageBox.Show(e.Message, "Info", MessageBoxButton.OK, MessageBoxImage.Information); }
        }
    }
}
