using System.Collections.Generic;

namespace nuelranks.pustalorc.xyz.JSON_Classes
{
    public class RainbowSixTeam
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public int AverageMmr { get; set; } = 0;
        public List<RainbowSixPlayer> Members { get; set; } = new List<RainbowSixPlayer>();
    }
}