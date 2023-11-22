using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling.Classes
{
    public class BowlingResult
    {
        private int pinsStanding = MAXPINS;
        public BowlingResult(short frame) 
        {
            Frame = frame;
        }

        public const int MAXPINS = 10;

        public short Frame;
        public byte Round { get; set; }
        public int Points => PinsPerRound.Sum(x => x);
        public int[] PinsPerRound { get; set; } = new int[3] { 0,0,0 }; 
        public int PinsStanding
        {
            get
            {
                return pinsStanding;
            }
            set
            {
                pinsStanding = value;
                if (pinsStanding < 0)
                {
                    pinsStanding = 0;
                }
            }
        }
        public bool RoundOver { get; set; }
    }
}
