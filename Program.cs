using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using nuelranks.pustalorc.xyz.JSON_Classes;

namespace nuelranks.pustalorc.xyz
{
    public class Program
    {
        public static List<SimpleTeam> SimpleTeams = new List<SimpleTeam>();

        public delegate void TeamsRefreshed();

        public static void RefreshTeams(TeamsRefreshed callback = null)
        {
            ThreadPool.QueueUserWorkItem(k =>
            {
                using (var web = new WebClient())
                {
                    var teams = new List<Team>();

                    foreach (var id in JsonConvert
                        .DeserializeObject<NuelTournament>(web.DownloadString(
                            "https://tournament-cms.dev.thenuel.com/rainbow-six-siege-university-league-winter-2019"))
                        .schedule.ToList().ConvertAll(k => k.tournamentId))
                    {
                        var team = JsonConvert.DeserializeObject<Tournament>(
                            web.DownloadString($"https://teams.dev.thenuel.com/signup-pools/{id}"));
                        if (team.teams.Count() > 0)
                            teams.AddRange(team.teams.Where(k => k.members.Count() >= 5).ToArray());
                    }

                    foreach (var team in teams)
                    {
                        var players = new List<SimplePlayer>();
                        foreach (var player in team.members.ToList()
                            .ConvertAll(k => k.inGameName?.displayName ?? k.userId))
                        {
                            var playerData = new PlayerData();
                            playerData = JsonConvert.DeserializeObject<PlayerData>(
                                web.DownloadString($"https://r6tab.com/api/search.php?platform=uplay&search={player}"));

                            if ((playerData?.results?.Length ?? 0) > 0)
                            {
                                var data = playerData.results[0];
                                players.Add(new SimplePlayer
                                {
                                    Name = player,
                                    Rank =
                                        $"https://trackercdn.com/cdn/r6.tracker.network/ranks/svg/hd-rank{data.p_currentrank}.svg",
                                    ProfilePicture =
                                        $"https://ubisoft-avatars.akamaized.net/{data.p_user}/default_146_146.png",
                                    MMR = data.p_currentmmr
                                });
                            }
                            else
                            {
                                players.Add(new SimplePlayer {Name = player, Rank = "", ProfilePicture = "", MMR = 0});
                            }
                        }

                        SimpleTeams.Add(new SimpleTeam() {Name = team.name, Members = players});
                    }
                }

                SimpleTeams.OrderBy(k => k.Name);
                callback?.Invoke();
            });
        }


        public static void Main(string[] args)
        {
            RefreshTeams();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());
        }
    }
}