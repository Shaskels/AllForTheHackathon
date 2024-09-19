using AllForTheHackathon.Employees;

namespace AllForTheHackathon.Strategies
{
    public class GaleShapleyStrategy : ITeamBuildingStrategy
    {
        private Dictionary<int, JuniorsData> _dictForJuns = new Dictionary<int, JuniorsData>();
        private Dictionary<int, TeamLeadsData> _dictForLeads = new Dictionary<int, TeamLeadsData>();
        private int _teamsSelected = 0;

        private class JuniorsData
        {
            public TeamLead Favorite { get; set; }
            public List<TeamLead> Candidates { get; set; } = new List<TeamLead>();
            public int IndOfBests { get; set; }

            public JuniorsData(TeamLead favorite)
            {
                IndOfBests = Сonstants.NumberOfTeams;
                Favorite = favorite;
            }
        }

        private class TeamLeadsData
        {
            public int IndOfBests { get; set; }
            public Answers answer { get; set; }

            public TeamLeadsData()
            {
                for (int i = 0; i < Сonstants.NumberOfTeams; i++)
                {
                    answer = Answers.No;
                    IndOfBests = -1;
                }
            }
        }

        private void MakeSuggestions(List<TeamLead> teamLeads)
        {
            for (int j = 0; j < Сonstants.NumberOfTeams; j++)
            {
                bool res = _dictForLeads.TryGetValue(teamLeads[j].Id, out TeamLeadsData? LeadData);
                if (res && LeadData?.answer == Answers.No)
                {
                    LeadData.IndOfBests += 1;
                    if (_dictForJuns.TryGetValue(teamLeads[j].Wishlist[LeadData.IndOfBests].Id, out JuniorsData? JunData))
                    {
                        JunData.Candidates.Add(teamLeads[j]);
                    }
                }
            }
        }

        private void ConsiderCandidates(Junior junior, JuniorsData JunData)
        {
            int currentBest = JunData.IndOfBests;
            foreach (TeamLead candidate in JunData.Candidates)
            {
                int index = junior.Wishlist.FindIndex(w => w.Id == candidate.Id);
                if (index < currentBest)
                {
                    TeamLeadsData? LeadData;
                    if (currentBest != Сonstants.NumberOfTeams)
                    {
                        if (_dictForLeads.TryGetValue(junior.Wishlist[currentBest].Id, out LeadData))
                        {
                            LeadData.answer = Answers.No;
                            _teamsSelected--;
                        }
                    }

                    if (_dictForLeads.TryGetValue(candidate.Id, out LeadData))
                    {
                        if (index == 0)
                        {
                            LeadData.answer = Answers.Yes;
                            _teamsSelected++;
                        }
                        else
                        {
                            LeadData.answer = Answers.Maybe;
                            _teamsSelected++;
                        }
                        currentBest = index;
                        JunData.Favorite = candidate;
                        JunData.IndOfBests = index;
                    }
                }
            }
        }

        private List<Team> FormTeams(List<Junior> juniors, List<TeamLead> teamLeads)
        {
            var teams = new List<Team>();
            for (int i = 0; i < Сonstants.NumberOfTeams; i++)
            {
                if (_dictForJuns.TryGetValue(juniors[i].Id, out JuniorsData? JunData))
                {
                    if (_dictForLeads.TryGetValue(teamLeads[JunData.IndOfBests].Id, out TeamLeadsData? LeadData))
                    {
                        var team = new Team(juniors[i], Сonstants.NumberOfTeams - JunData.IndOfBests, JunData.Favorite
                            , Сonstants.NumberOfTeams - LeadData.IndOfBests);
                        teams.Add(team);
                        Console.WriteLine(team);
                    }
                }
            }
            return teams;
        }

        private void FillDictionaries(List<Junior> juniors, List<TeamLead> teamLeads)
        {
            for (int i = 0; i < Сonstants.NumberOfTeams; i++)
            {
                var juniorsData = new JuniorsData(juniors[i].Wishlist[Сonstants.NumberOfTeams - 1]);
                var teamLeadsData = new TeamLeadsData();
                _dictForJuns.Add(juniors[i].Id, juniorsData);
                _dictForLeads.Add(teamLeads[i].Id, teamLeadsData);
            }
        }

        public List<Team> BuildTeams(List<Junior> juniors, List<TeamLead> teamLeads)
        {
            FillDictionaries(juniors, teamLeads);
            for (int i = 0; _teamsSelected < Сonstants.NumberOfTeams; i++)
            {
                MakeSuggestions(teamLeads);
                for (int j = 0; j < Сonstants.NumberOfTeams; j++)
                {
                    if (_dictForJuns.TryGetValue(juniors[j].Id, out JuniorsData? JunData))
                    {
                        ConsiderCandidates(juniors[j], JunData);
                        if (JunData.Candidates.Count() != 0)
                        {
                            JunData.Candidates.Clear();
                        }
                    }
                }
            }
            return FormTeams(juniors, teamLeads);
        }
    }
}
