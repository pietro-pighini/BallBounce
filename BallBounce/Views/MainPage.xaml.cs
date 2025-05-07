namespace BallBounce.Views;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private void OnPlayClicked(object sender, EventArgs e)
    {
        //devo creare la finestra GamePage
        //devo creare l'oggetto Game da passare a GamePage
        //devo quindi salvarmi il nome del giocatore
        //creando un ogetto ball
    }

    private void OnRulesClicked(object sender, EventArgs e)
    {
        // Navigazione alla pagina delle regole
        DisplayAlert("Rules", "Bounce the ball and don’t let it fall!", "Got it!");
    }
}
