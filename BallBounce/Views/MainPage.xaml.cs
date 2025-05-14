using BallBounceLibrary.Views;
namespace BallBounce.Views;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnPlayClicked(object sender, EventArgs e)
    {
        // Naviga semplicemente verso GamePage
        await Navigation.PushAsync(new GamePage());
    }

    private void OnRulesClicked(object sender, EventArgs e)
    {
        // Navigazione alla pagina delle regole
        DisplayAlert("Rules", "Bounce the ball and don’t let it fall!", "Got it!");
    }
}
