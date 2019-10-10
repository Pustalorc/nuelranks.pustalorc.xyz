using System.Collections.Generic;

namespace nuelranks.pustalorc.xyz.JSON_Classes
{
    public class SimpleTeam
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public List<SimplePlayer> Members { get; set; } = new List<SimplePlayer>();
    }
}