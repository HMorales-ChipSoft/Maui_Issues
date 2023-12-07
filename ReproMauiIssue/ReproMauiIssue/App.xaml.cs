namespace ReproMauiIssue
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();
        }

        public static ISheetService? Sheet { get; set; }
    }
}
