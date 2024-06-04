using Microsoft.Maui.Controls.PlatformConfiguration.AndroidSpecific;

namespace ReproMaui
{
    public partial class App : Microsoft.Maui.Controls.Application
    {
        public App()
        {
            InitializeComponent();

            Microsoft.Maui.Controls.TabbedPage tabbedPage = new Microsoft.Maui.Controls.TabbedPage
            {
                Children =
                {
                    new NavigationPage(new MainPage { Title = "Start_NavigationBar" }) { BarBackgroundColor = Colors.Red }
                }
            };

            tabbedPage.On<Microsoft.Maui.Controls.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);

            MainPage = tabbedPage;

            _ = Dispatcher.DispatchAsync(async () =>
            {
                await Task.Delay(3000);
                tabbedPage.Children[0] = new NavigationPage(new MainPage { Title = "New_NavigationBar" }) { BarBackgroundColor = Colors.Green };
            });
        }
    }
}
