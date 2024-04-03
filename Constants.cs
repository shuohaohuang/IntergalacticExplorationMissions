using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntergalacticExplorationMissions
{
    public class Constants
    {
        public const int Rows = 10,
            RequiredValues = 3,
            NameIndex = 0,
            MissionIndex = 1,
            ScoreIndex = 2;
        public const string
            Welcome = "Benvingut a Intergalactic Exploration Missions SL",
            Continue = "prem tecla per continuar",
            DataRequest = "Introdueix les informacions requerides",
            ErrorInput = "input invalida, torna a provar",
            Employee = "Empleat",
            Mission = "Missió",
            Score = "Punts",
            NameRequest = "Introdueix el nom del empleat",
            MissionRequest = "Introdueix el nom de la missió",
            ScoreRequest = "Introdueix la puntuació",
            NameConstraint = "Només lletres sense accents",
            MissionConstraint = "format: 'nom de consonent grega' - 'tres digits'",
            ScoreConstraint = "numeros entre [0-500]",
            RemainEmployee = "{0}/{1} empleats";
    }
}
