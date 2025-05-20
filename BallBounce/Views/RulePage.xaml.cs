namespace BallBounceLibrary.Views;

public partial class RulePage : ContentPage
{
    public RulePage()
    {
        InitializeComponent();
        RulesEditor.Text = @"1. Don't let the ball fall ";
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}