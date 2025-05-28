using System;
using System.Collections.Generic;
using BallBounce.Views;
using BallBounceLibrary.Models;
using Microsoft.Maui.Layouts;
namespace BallBounceLibrary.Views;
public enum GameStatus
{
    IN_PROGRESS,
    WON,
    LOST
}
public partial class GamePage : ContentPage
{
    public MainPage Main { get; set; }
    private readonly double LOWERING_SCREEN = 0.12;
    private readonly int MS_DELAY_OF_LOWERING = 5;
    public GameStatus Status { get; private set; } = GameStatus.IN_PROGRESS;
    public GamePage(Game game, MainPage main)
	{
        Main?.UpdatePlayerStats(CurrentGame.Player);
        Main = main;
		InitializeComponent();
        CurrentGame = game;
        AbsoluteLayout.SetLayoutBounds(img_ball, new Rect(CurrentGame.Player.PositionOfBall.X, CurrentGame.Player.PositionOfBall.Y, 90.0, 90.0));
        GeneratePlatformsOnLayout();
        bool isone = false;
        bool Generate = true;
        // Avvia un timer che chiama il metodo ogni secondo
        Dispatcher.StartTimer(TimeSpan.FromSeconds(1), () =>
        {
            LowerEveryPlatformAndAlsoPlayer();
            //dopo aver fatto il lowering devo creare altre piattaforme 
            //faccio che genera una volta si ed una volta no
            //perché sennó le piattaforme vengono tutte attaccate
            if (Generate) {
                CurrentGame.Platforms.Generate(isone, 0.0001);
                isone = !isone;
               
            }
            Generate = !Generate; // Alterna la generazione delle piattaforme

            //e ora devo aggiornare le immagini delle piataforme
            GeneratePlatformsOnLayout();
            CheckLostOrWon();
            RemovePlatformsOutOfBounds();//per rimuovere le piattaforme che sono fuori dallo schermo inutilizzate
            switch(Status){
                case GameStatus.LOST:
                    return false;
                case GameStatus.WON:
                    return false;
                case GameStatus.IN_PROGRESS:
                    return true;//perché se la  palla scende in basso devo dire che ha perso la partita
            }
            return true;//il valore di default
            
        });
    }//per favore non chiedetemi come funzioni questo device start timer e come mai non si blocchi la genetazione del costruttore , ma funziona e non si blocca la generazione del costruttore, quindi non lo tocco.
    private Game CurrentGame;
    public async void jump_left(object sender, EventArgs e)
    {
        //ogni volta che clicco devo resettare JumpHeigh.
        CurrentGame.JumpHeigh=Ball.JumpNormal;
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
    private void RemovePlatformsOutOfBounds()
    {
        // Rimuove le piattaforme che sono fuori dai limiti dello schermo
        for (int i = CurrentGame.Platforms.AllPlatforms.Count - 1; i >= 0; i--)
        {
            var platform = CurrentGame.Platforms.AllPlatforms[i];
            if (platform.CoordinatesOfPlatforms.Y < 0.0 || platform.CoordinatesOfPlatforms.Y > 1.0)
            {
                CurrentGame.Platforms.AllPlatforms.RemoveAt(i);
            }
        }
        //anche le immagini delle piattaforme devono essere rimosse
        for (int i = game_layout.Children.Count - 1; i >= 0; i--)
        {
            var child = game_layout.Children[i];
            if (child is Image img && (img.Source.ToString().Contains("platform") || img.Source.ToString().Contains("jumpingplat") || img.Source.ToString().Contains("trap")))
            {
                var bounds = AbsoluteLayout.GetLayoutBounds(img);
                if (bounds.Y < 0.0 || bounds.Y > 1.0)
                {
                    game_layout.Children.RemoveAt(i);
                }
            }
        }
    }
    public async void jump_right(object sender, EventArgs e)
    {
        //ogni volta che clicco devo resettare JumpHeigh.
        CurrentGame.JumpHeigh = Ball.JumpNormal;
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
    
    private async void LowerEveryPlatformAndAlsoPlayer()
    {
        // Abbassa ogni elemento della pagina di LOWERING_SCREEN
        foreach (var platform in CurrentGame.Platforms.AllPlatforms) { 
            platform.CoordinatesOfPlatforms.Y += LOWERING_SCREEN;
            // abbassa tutte le piattaforme generate da GeneratePlatformsOnLayout di LOWERING_SCREEN

        }
        foreach (var platform in game_layout.Children)
        {
            if (platform is Image img && (img.Source.ToString().Contains("platform")|| (img.Source.ToString().Contains("jumpingplat"))|| (img.Source.ToString().Contains("trap"))))
            {
                var bounds = AbsoluteLayout.GetLayoutBounds(img);
                AbsoluteLayout.SetLayoutBounds(img, new Rect(bounds.X, bounds.Y + LOWERING_SCREEN, bounds.Width, bounds.Height));
            }
        }
        CurrentGame.Player.PositionOfBall.Y += LOWERING_SCREEN;
        // aggiorna la posizione della palla sull'absolutelayout
        AbsoluteLayout.SetLayoutBounds(img_ball, new Rect(CurrentGame.Player.PositionOfBall.X, CurrentGame.Player.PositionOfBall.Y, 90.0, 90.0));
        await Task.Delay(MS_DELAY_OF_LOWERING);


    }
    private async void WonGame()
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
            CurrentGame.Player.Losses ++;
            Status = GameStatus.LOST;
        }
        else if (CurrentGame.Player.IsOnLastPlatform)
        {
            WonGame();
            CurrentGame.Player.Wins ++;
            Status = GameStatus.WON;
        }
        else
        {
            Status= Status = GameStatus.IN_PROGRESS;//o semplicemente non lo cambiavo ma volevo farlo
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