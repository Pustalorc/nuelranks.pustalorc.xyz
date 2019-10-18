using System.Collections.Generic;

namespace nuelranks.pustalorc.xyz.JSON_Classes
{
    public class LeagueOfLegendsTeam
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public List<LeagueOfLegendsPlayer> Members { get; set; } = new List<LeagueOfLegendsPlayer>();
    }
}