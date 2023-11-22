using Bowling.Classes;

namespace Bowling
{
    public class BowlingService
    {
        public BowlingService(Player player) 
        {
            Player = player;
            CurrentResult = GetPlayerResultForFrame(1);
        }
        public Player Player { get; set; }
        public short CurrentFrame { get; set; } = 1;
        public BowlingResult CurrentResult { get; set; }

        public void PlayGame(int playerThrow)
        {
            if(CurrentResult.Round >= 2)
            {
                CurrentFrame++;
                CurrentResult.RoundOver = true;
                Player.Results.Add(CurrentResult);
                CurrentResult = GetPlayerResultForFrame(CurrentFrame);
                CurrentResult.Frame = CurrentFrame;
                return;
            }
            GetBowlingResult(CurrentResult, playerThrow);

        }

        public BowlingResult GetBowlingResult(BowlingResult result, int playerThrow)
        {
            result.PinsStanding -= playerThrow;
            result.Points[result.Round] += playerThrow;
            result.Round++;

            if(result.PinsStanding <= 0) 
            {
                result.PinsStanding = BowlingResult.MAXPINS;
            }

            return result;
        }

        public void CreateBowlingTable()
        {
            Console.WriteLine("|-------------------------------------------------------------------|");
            Console.WriteLine("| Frame |  1  |  2  |  3  |  4  |  5  |  6  |  7  |  8  |  9  | 10  |");
            Console.WriteLine("|-------|-----|-----|-----|-----|-----|-----|-----|-----|-----|-----|");
		    Console.Write("|Points |");
            foreach(var result in Player.Results) 
            {
				Console.Write(" {0}|{1} |", result.Points[0], result.Points[1]);
            }
            Console.WriteLine();
            Console.WriteLine("|-------------------------------------------------------------------|");
        }

        private BowlingResult GetPlayerResultForFrame(short index)
        {
            return Player.Results.FirstOrDefault(r => r.Frame == index) ?? throw new Exception("Something went wrong when creating result");
        }

    }
}