namespace nuelranks.pustalorc.xyz.JSON_Classes
{
    public class SimplePlayer
    {
        public string PlayerID { get; set; } = "";
        public string Name { get; set; } = "";
        public int Rank { get; set; } = 0;
        public int MMR { get; set; } = 0;
        public bool IsCaptain { get; set; } = false;
    }
}