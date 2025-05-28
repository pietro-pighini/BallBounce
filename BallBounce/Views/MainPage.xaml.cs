using BallBounceLibrary.Models;
using BallBounceLibrary.Views;
namespace BallBounce.Views;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        _currentPlayer = new Ball(new Coordinates(0.5, 0.9), _username);
    }
    private string _username { get;set; } = "user";
    private List<Ball> _previousPlayers = new List<Ball>();
    private Ball _currentPlayer;

    private async void OnPlayClicked(object sender, EventArgs e)
    {
        // Naviga semplicemente verso GamePage
        PlatformGenerator platformGenerator = new PlatformGenerator();
        
        platformGenerator.AllPlatforms.Insert(0, new Platforms(new Coordinates(0.5, 0.999), PlatformType.Normal));//lo metto alla posizione 0
        Game game = new Game(_currentPlayer, platformGenerator, new PowerUpGenerator(platformGenerator.AllPlatforms));
        await Navigation.PushAsync(new GamePage(game, this));
    }
    private async void OnRulesClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RulePage());
    }
    private async void OnEntryCompleted(object sender, EventArgs e)
    {
        Entry entry = sender as Entry;
        int index = IsAlreadyUsed(entry.Text);
        if (index!=-1)
        {
            _currentPlayer = _previousPlayers[index];
        }
        else
        {
            _currentPlayer = new Ball(new Coordinates(0.5, 0.9), entry.Text);
        }

    }
    private int IsAlreadyUsed(string name)
    {
        for(int i=0;i<_previousPlayers.Count;i++)
        {
            if (_previousPlayers[i].Username == name)
            {
                return i;
            }
        }
        return -1;
    }

    // In MainPage.xaml.cs
    public void UpdatePlayerStats(Ball player)
    {
        Username.Text = $"Username: {player.Username}";
        Wins.Text = $"Partite vinte: {player.Wins}";
        Losses.Text = $"Partite perse: {player.Losses}";
    }

}
