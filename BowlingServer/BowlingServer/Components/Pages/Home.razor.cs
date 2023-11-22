using Bowling.Classes;
using Bowling.Interfaces;
using Microsoft.AspNetCore.Components;

namespace BowlingServer.Components.Pages
{
    public partial class Home
    {
        [Inject]
        public IBowlingService BowlingService { get; set; }

        protected override void OnInitialized()
        {
            var player = new Player();
            player.Name = "John Bowling";
            BowlingService.InitializeGame(player);
        }

        public void PlayRound() 
        {
            var random = new Random().Next(0, 10);
            BowlingService.PlayGame(random);
        }
    }
}