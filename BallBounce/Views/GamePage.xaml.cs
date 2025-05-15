using BallBounceLibrary.Models;	
namespace BallBounceLibrary.Views;
public partial class GamePage : ContentPage
{
	public GamePage(Game game)
	{
		InitializeComponent();
        CurrentGame = game;
        AbsoluteLayout.SetLayoutBounds(img_ball, new Rect(CurrentGame.Player.PositionOfBall.X, CurrentGame.Player.PositionOfBall.Y, 90.0, 90.0));
    }
	private Game CurrentGame;
    public async void jump_left(object sender, EventArgs e)
    {
        //ogni volta che clicco devo resettare JumpHeigh.
        CurrentGame.JumpHeigh=Ball.JumpNormal;
        double gravity = 0;
        do
        {
            CurrentGame.Move(-1);
            CurrentGame.Jump(gravity += 0.5);
            AbsoluteLayout.SetLayoutBounds(img_ball, new Rect(CurrentGame.Player.PositionOfBall.X, CurrentGame.Player.PositionOfBall.Y, 90.0, 90.0));
            await Task.Delay(100); // Aggiunge un delay di 0.05 secondi
            
        }while (CurrentGame.Player.IsJumping||CurrentGame.Player.IsFalling);
    }
    public async void jump_right(object sender, EventArgs e)
    {
        //ogni volta che clicco devo resettare JumpHeigh.
        CurrentGame.JumpHeigh = Ball.JumpNormal;
        double gravity = 0;
        do
        {
            CurrentGame.Move(+1);
            CurrentGame.Jump(gravity += 0.5);
            AbsoluteLayout.SetLayoutBounds(img_ball, new Rect(CurrentGame.Player.PositionOfBall.X, CurrentGame.Player.PositionOfBall.Y, 90.0, 90.0));

            await Task.Delay(100); // Aggiunge un delay di 0.05 secondi
        } while (CurrentGame.Player.IsJumping);
        do
        {
            CurrentGame.Player.GoDown();
            AbsoluteLayout.SetLayoutBounds(img_ball, new Rect(CurrentGame.Player.PositionOfBall.X, CurrentGame.Player.PositionOfBall.Y, 90.0, 90.0));
            await Task.Delay(100); // Aggiunge un delay di 0.05 secondi

        } while (CurrentGame.Player.IsFalling);
    }
}