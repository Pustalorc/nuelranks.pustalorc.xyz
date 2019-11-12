using System.Collections.Generic;

namespace nuelranks.pustalorc.xyz.JSON_Classes
{
    public class LeagueOfLegendsTeam : TournamentTeam
    {
        public string AverageRank { get; set; } = "";
        public List<LeagueOfLegendsPlayer> Players { get; set; }
    }
}