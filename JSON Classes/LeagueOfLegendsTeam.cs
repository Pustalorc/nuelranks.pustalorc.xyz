using Newtonsoft.Json;
using System.Collections.Generic;

namespace nuelranks.pustalorc.xyz.JSON_Classes
{
    public abstract class TournamentTeam
    {
        public Tournament Tournament { get; set; } = null;
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";

        [JsonIgnore]
        public List<TeamPlayer> Members { get; set; } = new List<TeamPlayer>();
    }
    public class LeagueOfLegendsTeam : TournamentTeam
    {
        public string AverageRank { get; set; } = "";
        public List<LeagueOfLegendsPlayer> Players { get; set; }
    }
}