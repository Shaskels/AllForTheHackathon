using AllForTheHackathon.Employees;

namespace AllForTheHackathon
{
    public static class Registrar
    {
        private static void Register<T>(string file, List<T> participants)
        {
            if (File.Exists(@"..\..\..\" + file))
            {
                var textFile = new StreamReader(@"..\..\..\" + file);
                string? line = textFile.ReadLine();

                while ((line = textFile.ReadLine()) != null)
                {
                    string[] participant = line.Split(";");
                    string name = participant[1];
                    if (int.TryParse(participant[0], out int id))
                    {
                        var p = Activator.CreateInstance(typeof(T), id, name);
                        if (p != null)
                        {
                            participants.Add((T)p);
                        }
                    }
                    else
                    {
                        throw new RegistrationException("The employee Id must be a number and must not be empty");
                    }
                }

                if (participants.Count != Consts.NumberOfTeams)
                {
                    throw new RegistrationException("The number of Juniors and Teamleads must match the number of teams:" + Consts.NumberOfTeams);
                }


                textFile.Close();
            }
        }

        public static (List<Junior>, List<TeamLead>) RegisterParticipants(string fileNameWithJuniors, string fileNameWithTeamLeaders)
        {
            List<Junior> Juniors = new List<Junior>();
            List<TeamLead> TeamLeads = new List<TeamLead>();
            Register<Junior>(fileNameWithJuniors, Juniors);
            Register<TeamLead>(fileNameWithTeamLeaders, TeamLeads);
            Console.WriteLine(Juniors.ToString());
            Console.WriteLine(TeamLeads.ToString());
            return (Juniors, TeamLeads);
        }
    }
}
