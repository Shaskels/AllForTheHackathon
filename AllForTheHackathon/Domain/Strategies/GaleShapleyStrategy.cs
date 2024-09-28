using AllForTheHackathon.Domain.Employees;
using Microsoft.Extensions.Options;

namespace AllForTheHackathon.Domain.Strategies
{
    public class GaleShapleyStrategy : ITeamBuildingStrategy
    {
        private Dictionary<int, JuniorsData> _dictForJuns = new Dictionary<int, JuniorsData>();
        private Dictionary<int, TeamLeadsData> _dictForLeads = new Dictionary<int, TeamLeadsData>();
        private int _teamsSelected = 0;
        private int _teamLeadsNumber = 0;

        private class JuniorsData
        {
            public TeamLead Favorite { get; set; }
            public List<TeamLead> Candidates { get; set; } = new List<TeamLead>();
            public int IndOfBests { get; set; }

            public JuniorsData(TeamLead favorite, int numberOfLeads)
            {
                IndOfBests = numberOfLeads;
                Favorite = favorite;
            }
        }

        private class TeamLeadsData
        {
            public int IndOfBests { get; set; }
            public Answers answer { get; set; }

            public TeamLeadsData()
            {
                answer = Answers.No;
                IndOfBests = -1;
            }
        }

        private void MakeSuggestions(List<TeamLead> teamLeads)
        {
            foreach (TeamLead teamLead in teamLeads)
            {
                bool res = _dictForLeads.TryGetValue(teamLead.Id, out TeamLeadsData? LeadData);
                if (res && LeadData?.answer == Answers.No)
                {
                    LeadData.IndOfBests += 1;
                    if (_dictForJuns.TryGetValue(teamLead.Wishlist[LeadData.IndOfBests].Id, out JuniorsData? JunData))
                    {
                        JunData.Candidates.Add(teamLead);
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
                    if (currentBest != _teamLeadsNumber)
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
            foreach (Junior junior in juniors)
            {
                if (_dictForJuns.TryGetValue(junior.Id, out JuniorsData? JunData))
                {
                    if (_dictForLeads.TryGetValue(teamLeads[JunData.IndOfBests].Id, out TeamLeadsData? LeadData))
                    {
                        var team = new Team(junior,
                            juniors.Count - JunData.IndOfBests,
                            JunData.Favorite,
                            juniors.Count - LeadData.IndOfBests);
                        teams.Add(team);
                    }
                }
            }
            return teams;
        }

        private void FillDictionaries(List<Junior> juniors, List<TeamLead> teamLeads)
        {
            _dictForJuns.Clear();
            _dictForLeads.Clear();
            for (int i = 0; i < juniors.Count; i++)
            {
                var juniorsData = new JuniorsData(juniors[i].Wishlist[juniors.Count - 1], _teamLeadsNumber);
                var teamLeadsData = new TeamLeadsData();
                _dictForJuns.Add(juniors[i].Id, juniorsData);
                _dictForLeads.Add(teamLeads[i].Id, teamLeadsData);
            }
        }

        public List<Team> BuildTeams(List<Junior> juniors, List<TeamLead> teamLeads)
        {
            _teamsSelected = 0;
            _teamLeadsNumber = juniors.Count;
            FillDictionaries(juniors, teamLeads);
            for (int i = 0; _teamsSelected < juniors.Count; i++)
            {
                MakeSuggestions(teamLeads);
                foreach (Junior junior in juniors)
                {
                    if (_dictForJuns.TryGetValue(junior.Id, out JuniorsData? JunData))
                    {
                        ConsiderCandidates(junior, JunData);
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
