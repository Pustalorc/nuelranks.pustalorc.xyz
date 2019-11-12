namespace nuelranks.pustalorc.xyz.JSON_Classes
{
    public abstract class TeamPlayer
    {
        public string PlayerId { get; set; } = "";
        public string Name { get; set; } = "";
        public bool IsCaptain { get; set; } = false;
    }
    public class LeagueOfLegendsPlayer : TeamPlayer
    {
        public string Rank { get; set; } = "default";
        public int NumericRank { get; set; } = 0;
        public int ProfileIconId { get; set; } = 0;
    }
}