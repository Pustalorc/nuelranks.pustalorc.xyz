namespace nuelranks.pustalorc.xyz.JSON_Classes
{
    public class LeagueOfLegendsPlayer
    {
        public string PlayerId { get; set; } = "";
        public string Name { get; set; } = "";
        public string TftRank { get; set; } = "default";
        public string Rank { get; set; } = "default";
        public bool IsCaptain { get; set; } = false;
        public int ProfileIconId { get; set; } = 0;
    }
}