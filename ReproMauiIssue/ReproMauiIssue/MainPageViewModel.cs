using System.ComponentModel;
using System.Windows.Input;

namespace ReproMauiIssue
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public MainPageViewModel()
        {
            ShowSheetCommand = new Command(obj => App.Sheet?.ShowPage(new MainPage()));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private bool _isToggled;
        public bool IsToggled
        {
            get => _isToggled;
            set
            {
                _isToggled = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsToggled)));
            }
        }

        public ICommand ShowSheetCommand { get; set; }
    }
}
