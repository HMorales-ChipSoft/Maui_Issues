using Microsoft.Maui.Controls.PlatformConfiguration.AndroidSpecific;
using System.ComponentModel;
using System.Windows.Input;

namespace ReproMaui
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public MainPageViewModel()
        {
            ShowModalCommand = new Command(async obj => 
            {
                Microsoft.Maui.Controls.TabbedPage tabbedPage = new Microsoft.Maui.Controls.TabbedPage
                {
                    Children =
                    {
                        new NavigationPage(new MainPage { Title = "Start_Modal_NavigationBar" }) { BarBackgroundColor = Colors.Red }
                    }
                };

                tabbedPage.On<Microsoft.Maui.Controls.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);

                if (Microsoft.Maui.Controls.Application.Current?.MainPage?.Navigation is INavigation navigation)
                {
                    await navigation.PushModalAsync(tabbedPage);
                }

                await Task.Delay(3000);
                tabbedPage.Children[0] = new NavigationPage(new MainPage { Title = "New_Modal_NavigationBar" }) { BarBackgroundColor = Colors.Green };
            });
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public ICommand ShowModalCommand { get; set; }
    }
}
