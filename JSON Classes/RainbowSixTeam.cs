using System.Collections.Generic;

namespace nuelranks.pustalorc.xyz.JSON_Classes
{
    public class RainbowSixTeam : TournamentTeam
    {
        public int AverageMmr { get; set; } = 0;

        public List<RainbowSixPlayer> Players { get; set; }
    }
}