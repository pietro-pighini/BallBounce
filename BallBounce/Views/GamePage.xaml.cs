using System;
using System.Collections.Generic;
using BallBounce.Views;
using BallBounceLibrary.Models;
using Microsoft.Maui.Layouts;
namespace BallBounceLibrary.Views;
public partial class GamePage : ContentPage
{
    public MainPage Main { get; set; }
    public GamePage(Game game, MainPage main)
	{
        Main = main;
		InitializeComponent();
        CurrentGame = game;
        AbsoluteLayout.SetLayoutBounds(img_ball, new Rect(CurrentGame.Player.PositionOfBall.X, CurrentGame.Player.PositionOfBall.Y, 90.0, 90.0));
        GeneratePlatformsOnLayout();
    }
	private Game CurrentGame;
    public async void jump_left(object sender, EventArgs e)
    {
        //ogni volta che clicco devo resettare JumpHeigh.
        CurrentGame.JumpHeigh=Ball.JumpNormal;
        double gravity = 0;
        int timescicled = 0;
        do
        {
            CurrentGame.Move(-1);
            CurrentGame.Jump();
            AbsoluteLayout.SetLayoutBounds(img_ball, new Rect(CurrentGame.Player.PositionOfBall.X, CurrentGame.Player.PositionOfBall.Y, 90.0, 90.0));
            await Task.Delay(40); // Aggiunge un delay di 0.05 secondi
            
        }while (CurrentGame.Player.IsJumping);//
        CurrentGame.Player.IsFalling = true;
        while (CurrentGame.Player.IsFalling && timescicled <= 10)
        {
            CurrentGame.GoDown();
            AbsoluteLayout.SetLayoutBounds(img_ball, new Rect(CurrentGame.Player.PositionOfBall.X, CurrentGame.Player.PositionOfBall.Y, 90.0, 90.0));
            await Task.Delay(10); // Aggiunge un delay di 0.05 secondi
            timescicled++;
        }
        CheckLostOrWon();
    }
    public async void jump_right(object sender, EventArgs e)
    {
        //ogni volta che clicco devo resettare JumpHeigh.
        CurrentGame.JumpHeigh = Ball.JumpNormal;
        double gravity = 0;
        int timescicled = 0;
        do
        {
            CurrentGame.Move(+1);
            CurrentGame.Jump();
            AbsoluteLayout.SetLayoutBounds(img_ball, new Rect(CurrentGame.Player.PositionOfBall.X, CurrentGame.Player.PositionOfBall.Y, 90.0, 90.0));

            await Task.Delay(40); // Aggiunge un delay di 0.05 secondi
        } while (CurrentGame.Player.IsJumping);
        CurrentGame.Player.IsFalling = true;
        while (CurrentGame.Player.IsFalling&&timescicled<=10) 
        {
            CurrentGame.GoDown();
            AbsoluteLayout.SetLayoutBounds(img_ball, new Rect(CurrentGame.Player.PositionOfBall.X, CurrentGame.Player.PositionOfBall.Y, 90.0, 90.0));
            await Task.Delay(10); // Aggiunge un delay di 0.05 secondi
            timescicled++;  
        }
        CheckLostOrWon();
        ModifYJumpHeighBasedOnPlatformType();
    }
    public async void jump_straight(object sender, EventArgs e)
    {
        //ogni volta che clicco devo resettare JumpHeigh.

        CurrentGame.JumpHeigh -= 0.04;
        double gravity = 0;
        int timescicled = 0;
        do
        {
            CurrentGame.Jump();
            AbsoluteLayout.SetLayoutBounds(img_ball, new Rect(CurrentGame.Player.PositionOfBall.X, CurrentGame.Player.PositionOfBall.Y, 90.0, 90.0));
            await Task.Delay(40); // Aggiunge un delay di 0.05 secondi
        } while (CurrentGame.Player.IsJumping);
        CurrentGame.Player.IsFalling = true;
        while (CurrentGame.Player.IsFalling && timescicled <= 10)
        {
            CurrentGame.GoDown();
            AbsoluteLayout.SetLayoutBounds(img_ball, new Rect(CurrentGame.Player.PositionOfBall.X, CurrentGame.Player.PositionOfBall.Y, 90.0, 90.0));
            await Task.Delay(10); // Aggiunge un delay di 0.05 secondi
            timescicled++;
        }
        CheckLostOrWon();
        ModifYJumpHeighBasedOnPlatformType();

    }
    private void GeneratePlatformsOnLayout()
    {
        PlatformGenerator generator = new();
        List<Platforms> platforms = CurrentGame.Platforms.AllPlatforms;

        foreach (var platform in platforms)
        {
            Image platformImage = new Image
            {
                Source = GetPlatformImageSource(platform.TypeOfPlatform),
                WidthRequest = 120,
                HeightRequest = 120
            };

            // Imposta il layout bounds con valori relativi
            AbsoluteLayout.SetLayoutBounds(platformImage,
                new Rect(platform.CoordinatesOfPlatforms.X, platform.CoordinatesOfPlatforms.Y, 120, 120));
            AbsoluteLayout.SetLayoutFlags(platformImage, AbsoluteLayoutFlags.PositionProportional);

            game_layout.Children.Add(platformImage);
        }
    }
    private async void WonGame()
    {
        if (CurrentGame.Player.IsOnLastPlatform)
        {
            // Mostra un messaggio di vittoria  
            bool retry = await DisplayAlert("CONTRATULATIONS!", "You won the game!", "Play Again", "ESC");
            if (retry)
            {
                // Crea una nuova istanza del gioco e della pagina  
                PlatformGenerator platformGenerator = new PlatformGenerator();
                Coordinates coords = new Coordinates(0.5, 0.9);
                platformGenerator.AllPlatforms.Insert(0, new Platforms(new Coordinates(0.5, 0.999), PlatformType.Normal)); // lo metto alla posizione 0  
                Game game = new Game(new Ball(coords, "gigi"), platformGenerator, new PowerUpGenerator(platformGenerator.AllPlatforms));
                await Navigation.PushAsync(new GamePage(game, this.Main));
            }
            else
            {
                // Chiude la finestra corrente e riapre la MainPage  
                await Navigation.PopToRootAsync();
            }
        }
    }
    private bool IsOutOfBounds()
    {
        var bounds = AbsoluteLayout.GetLayoutBounds(img_ball);
        if (bounds.X < 0.0 || bounds.Y > 1.0 || bounds.X > 1.0)
        {
            return true;
        }
        return false;
    }
    private async void LostGame()
    {
        bool retry = await DisplayAlert("Game Over", "You lost the game!", "Try Again", "ESC");
        if (retry)
        {
            // Crea una nuova istanza del gioco e della pagina  
            PlatformGenerator platformGenerator = new PlatformGenerator();
            Coordinates coords = new Coordinates(0.5, 0.9);
            platformGenerator.AllPlatforms.Insert(0, new Platforms(new Coordinates(0.5, 0.999), PlatformType.Normal));//lo metto alla posizone 0
            Game game = new Game(new Ball(coords, "gigi"), platformGenerator, new PowerUpGenerator(platformGenerator.AllPlatforms));
            await Navigation.PushAsync(new GamePage(game,this.Main));
            //ora devo chiudere questa pagina peró
        }
        else
        {
            // Chiude la finestra corrente e riapre la MainPage  
            await Navigation.PopToRootAsync();
        }
    }
    private void CheckLostOrWon()
    {
        if (IsOutOfBounds())
        {
            LostGame();
        }
        else
        {
            WonGame();
        }
    }
    private void ModifYJumpHeighBasedOnPlatformType()
    {
        if(CurrentGame.Player.IsOnNormal)
        {
            CurrentGame.JumpHeigh = Ball.JumpNormal;
        }
        else if (CurrentGame.Player.IsOnTrap)
        {
            CurrentGame.JumpHeigh = Ball.JumpPenalty;
        }
        else if (CurrentGame.Player.IsOnTrampoline)
        {
            CurrentGame.JumpHeigh = Ball.JumpBoost;
        }
    }
    private string GetPlatformImageSource(PlatformType type)
    {
        return type switch
        {
            PlatformType.Normal => "platform.png",
            PlatformType.Trampoline => "jumpingplat.png",
            PlatformType.Trap => "trap.png",
            _ => "platform.png"
        };
    }

}