using System.Diagnostics;

namespace IntergalacticExplorationMissions
{
    class Program
    {
        static void Main()
        {
            Dictionary<int, string> valuesRequest = new Dictionary<int, string>
            {
                { 0, Constants.NameRequest },
                { 1, Constants.MissionRequest },
                { 2, Constants.ScoreRequest }
            };
            Dictionary<int, string> valuesConstains = new Dictionary<int, string>
            {
                { 0, Constants.NameConstraint },
                { 1, Constants.MissionConstraint },
                { 2, Constants.ScoreConstraint }
            };

            List<Score> scores = new List<Score>();

            Console.WriteLine(Constants.Welcome);
            Console.WriteLine(Constants.Continue);
            Console.ReadKey();
            Console.Clear();

            for (int i = 0; i < Constants.Rows; i++)
            {
                string userInput;
                List<string> input = new List<string>();
                Console.WriteLine(Constants.DataRequest);

                for (int j = 0; j < Constants.RequiredValues; j++)
                {
                    bool valid = false;
                    do
                    {
                        Console.WriteLine(valuesRequest[j]);
                        Console.WriteLine(valuesConstains[j]);
                        userInput = Console.ReadLine() ?? "";
                        //switch case para cambiar la invocacion de metodos comprovador
                        switch (j)
                        {
                            case 0:
                                valid = Score.CheckName(userInput);
                                break;
                            case 1:
                                valid = Score.CheckMission(userInput);
                                break;
                            case 2:
                                valid = Score.CheckScore(userInput);
                                break;
                        }

                        Console.Clear();

                        if (!valid)
                        {
                            Console.WriteLine(Constants.ErrorInput);
                        }
                        else
                        {
                            input.Add(userInput);
                        }

                    } while (!valid);
                }
                //si los inputs son correctos se añaden a la lista scores
                scores.Add(
                    new(
                        input[Constants.NameIndex],
                        input[Constants.MissionIndex],
                        Convert.ToInt32(input[Constants.ScoreIndex])
                    )
                );
            }
            //Printa el ranking

            Console.WriteLine($"{Constants.Employee}\t\t{Constants.Mission}\t\t{Constants.Score}");
            foreach (Score score in Score.GenerateUniqueRanking(scores))
                Console.WriteLine(score.ToString());
        }
    }
}
