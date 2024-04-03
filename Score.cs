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
            //Lista que contiene las letras griegas
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

            //separa el parametro de entrada por '-'
            string[] name = mission.ToLower().Split('-');
            //Si el parametro no contiene '-', la congitud de name es 1 retorna false
            //Si no la lista de letras no contiene el name[0], comienza con (letra griega), retorna false
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

            // ordeno la lista entrante por puntucion
            scores.Sort();
            for (int i = 0; i < scores.Count(); i++)
            {

                if (!viewedMission.Contains(scores[i].Mission))
                {
                    List<Score> player = scores
                        .Where(score => score.Mission == scores[i].Mission) //filtro todas las missiones del mismo tipo
                        .GroupBy(score => score.Player) // de las filtradas las agrupa por empleado
                        .Select(p => p.First()) // y selecciona el primero de la lista, és el mayor ya que la lista inicial se ordeno previamente
                        .ToList();
                    viewedMission.Add(scores[i].Mission);

                    // se anade todo el contenido de la lista al resultado final
                    foreach (Score score in player)
                        ranking.Add(score);
                }
            }
            // se ordena el resultado final
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
