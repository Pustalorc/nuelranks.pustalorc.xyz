using System.Collections.Generic;
using Newtonsoft.Json;

namespace nuelranks.pustalorc.xyz.JSON_Classes
{
    public abstract class TournamentTeam
    {
        public Tournament Tournament { get; set; } = null;
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";

        [JsonIgnore] public List<TeamPlayer> Members { get; set; } = new List<TeamPlayer>();
    }
}