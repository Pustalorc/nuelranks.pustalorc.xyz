namespace nuelranks.pustalorc.xyz.JSON_Classes
{
    public class LeagueOfLegendsPlayer : TeamPlayer
    {
        public string Rank { get; set; } = "default";
        public int NumericRank { get; set; } = 0;
        public int ProfileIconId { get; set; } = 0;
    }
}