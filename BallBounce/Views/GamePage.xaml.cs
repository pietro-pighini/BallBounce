using System;
using System.Collections.Generic;

using BallBounceLibrary.Models;
using Microsoft.Maui.Layouts;
namespace BallBounceLibrary.Views;
public partial class GamePage : ContentPage
{
	public GamePage(Game game)
	{
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
            CurrentGame.Jump(gravity);
            AbsoluteLayout.SetLayoutBounds(img_ball, new Rect(CurrentGame.Player.PositionOfBall.X, CurrentGame.Player.PositionOfBall.Y, 90.0, 90.0));
            await Task.Delay(100); // Aggiunge un delay di 0.05 secondi
            
        }while (CurrentGame.Player.IsJumping);//
        do
        {
            CurrentGame.GoDown();
            AbsoluteLayout.SetLayoutBounds(img_ball, new Rect(CurrentGame.Player.PositionOfBall.X, CurrentGame.Player.PositionOfBall.Y, 90.0, 90.0));
            await Task.Delay(100); // Aggiunge un delay di 0.05 secondi
            timescicled++;
        } while (CurrentGame.Player.IsFalling&&timescicled!=20);
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
            CurrentGame.Jump(gravity += 0.5);
            AbsoluteLayout.SetLayoutBounds(img_ball, new Rect(CurrentGame.Player.PositionOfBall.X, CurrentGame.Player.PositionOfBall.Y, 90.0, 90.0));

            await Task.Delay(100); // Aggiunge un delay di 0.05 secondi
        } while (CurrentGame.Player.IsJumping);
        do
        {
            AbsoluteLayout.SetLayoutBounds(img_ball, new Rect(CurrentGame.Player.PositionOfBall.X, CurrentGame.Player.PositionOfBall.Y, 90.0, 90.0));
            await Task.Delay(100); // Aggiunge un delay di 0.05 secondi
            timescicled++;  
        } while (CurrentGame.Player.IsFalling && timescicled != 20);
    }


    private void GeneratePlatformsOnLayout()
    {
        PlatformGenerator generator = new();
        List<Platforms> platforms = generator.Generate();

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