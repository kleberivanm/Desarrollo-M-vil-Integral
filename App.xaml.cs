namespace AppMESAPP
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Establece la LoginPage como la pantalla inicial usando NavigationPage
            MainPage = new NavigationPage(new LoginPage());
        }
    }
}

