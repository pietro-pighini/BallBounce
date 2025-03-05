using DemoPWMaui.Views;

namespace DemoPWMaui
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // NAVIGAZIONE: impostata la schermata iniziale dell'app,
            // ovvero la 'root page' alla base dello stack di navigazione.  

            MainPage = new NavigationPage(new ListPage());
        }
    }
}
