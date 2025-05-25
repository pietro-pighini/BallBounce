using BallBounceLibrary.Models;
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
        PlatformGenerator platformGenerator = new PlatformGenerator();
        Coordinates coords = new Coordinates(0.5, 0.9);
        platformGenerator.AllPlatforms.Insert(0, new Platforms(new Coordinates(0.5, 0.999), PlatformType.Normal));//lo metto alla posizione 0
        Game game = new Game(new Ball(coords, "gigi"), platformGenerator, new PowerUpGenerator(platformGenerator.AllPlatforms));
        await Navigation.PushAsync(new GamePage(game, this));
    }
    private async void OnRulesClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RulePage());
    }

}
