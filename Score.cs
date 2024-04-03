using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IntergalacticExplorationMissions
{
    public class Score : IComparable<Score>
    {
        public string Player { get; set; }
        public string Mission { get; set; }
        public int Scoring { get; set; }

        public Score(string player, string mission, int scoring)
        {
            Player = player;
            Mission = mission;
            Scoring = scoring;
        }

        public static bool CheckName(string name)
        {
            Regex regex = new Regex("[a-z]", RegexOptions.IgnoreCase);
            return regex.IsMatch(name);
        }

        public static bool CheckMission(string mission)
        {
            List<string> consonantes = new List<string>
            {
                "beta",
                "gamma",
                "delta",
                "zeta",
                "theta",
                "kappa",
                "lambda",
                "mi",
                "mu",
                "nu",
                "ni",
                "ksi",
                "pi",
                "ro",
                "sigma",
                "tau",
                "pi",
                "khi",
                "psi",
                "omega"
            };

            string[] name = mission.ToLower().Split('-');
            return consonantes.Contains(name[0].Trim()) && name.Length > 1;
        }

        public static bool CheckScore(string score)
        {
            if (int.TryParse(score, out int number))
                return number >= 0 && number <= 500;
            return false;
        }

        public static List<Score> GenerateUniqueRanking(List<Score> scores)
        {
            List<Score> ranking = new List<Score>();
            List<string> viewedMission = new List<string>();
            scores.Sort();
            for (int i = 0; i < scores.Count(); i++)
            {
                List<Score> player = scores
                    .Where(score => score.Mission == scores[i].Mission)
                        .GroupBy(score => score.Player)
                        .Select(p => p.First())
                        .ToList();
                if (!viewedMission.Contains(scores[i].Mission))
                {
                    viewedMission.Add(scores[i].Mission);
                    
                    
                    foreach (Score score in player)
                        ranking.Add(score);
                }
            }
            ranking.Sort();
            return ranking;
        }

        public int CompareTo(Score? other)
        {
            if (other == null)
                return 1;
            return other.Scoring.CompareTo(this.Scoring);
        }

        public string ToString()
        {
            return $"{this.Player}\t\t{this.Mission}\t\t{this.Scoring}";
        }
    }
}
