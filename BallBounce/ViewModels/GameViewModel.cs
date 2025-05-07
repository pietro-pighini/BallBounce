using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BallBounceLibrary.Models;
namespace BallBounceLibrary.ViewModels
{
    public partial class GameViewModel:ObservableObject
    {
        [ObservableProperty]
        private Ball _gameBall;
    }
}
