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
            public Employee Favorite { get; set; }
            public List<TeamLead> Candidates { get; set; } = new List<TeamLead>();
            public int IndOfBests { get; set; }

            public JuniorsData(Employee favorite, int numberOfLeads)
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

        private void MakeSuggestions(List<TeamLead> teamLeads, List<Wishlist> teamLeadsWishlists)
        {
            for (int i = 0; i < teamLeads.Count; i++)
            {
                bool res = _dictForLeads.TryGetValue(teamLeads[i].IdInList, out TeamLeadsData? LeadData);
                if (res && LeadData?.answer == Answers.No)
                {
                    LeadData.IndOfBests += 1;
                    if (_dictForJuns.TryGetValue(teamLeadsWishlists[i].Employees[LeadData.IndOfBests].IdInList, out JuniorsData? JunData))
                    {
                        JunData.Candidates.Add(teamLeads[i]);
                    }
                }
            }
        }

        private void ConsiderCandidates(Junior junior, JuniorsData JunData, Wishlist juniorWishlist)
        {
            int currentBest = JunData.IndOfBests;
            foreach (TeamLead candidate in JunData.Candidates)
            {
                int index = juniorWishlist.Employees.FindIndex(w => w.IdInList == candidate.IdInList);
                if (index < currentBest)
                {
                    TeamLeadsData? LeadData;
                    if (currentBest != _teamLeadsNumber)
                    {
                        if (_dictForLeads.TryGetValue(juniorWishlist.Employees[currentBest].IdInList, out LeadData))
                        {
                            LeadData.answer = Answers.No;
                            _teamsSelected--;
                        }
                    }

                    if (_dictForLeads.TryGetValue(candidate.IdInList, out LeadData))
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
                if (_dictForJuns.TryGetValue(junior.IdInList, out JuniorsData? JunData))
                {
                    if (_dictForLeads.TryGetValue(teamLeads[JunData.IndOfBests].IdInList, out TeamLeadsData? LeadData))
                    {
                        var team = new Team(junior, teamLeads.Count - JunData.IndOfBests, JunData.Favorite,
                            juniors.Count - LeadData.IndOfBests);
                        teams.Add(team);
                    }
                }
            }
            return teams;
        }

        private void FillDictionaries(List<Junior> juniors, List<TeamLead> teamLeads,
            List<Wishlist> juniorsWishlists)
        {
            _dictForJuns.Clear();
            _dictForLeads.Clear();
            for (int i = 0; i < juniors.Count; i++)
            {
                var juniorsData = new JuniorsData(juniorsWishlists[i].Employees[juniors.Count - 1], _teamLeadsNumber);
                var teamLeadsData = new TeamLeadsData();
                _dictForJuns.Add(juniors[i].IdInList, juniorsData);
                _dictForLeads.Add(teamLeads[i].IdInList, teamLeadsData);
            }
        }

        public List<Team> BuildTeams(List<Junior> juniors, List<TeamLead> teamLeads,
            List<Wishlist> juniorsWishlists, List<Wishlist> teamLeadsWishlists)
        {
            _teamsSelected = 0;
            _teamLeadsNumber = juniors.Count;

            FillDictionaries(juniors, teamLeads, juniorsWishlists);
            for (int i = 0; _teamsSelected < juniors.Count; i++)
            {
                MakeSuggestions(teamLeads, teamLeadsWishlists);
                for (var j = 0; j < juniors.Count; j++)
                {
                    if (_dictForJuns.TryGetValue(juniors[j].IdInList, out JuniorsData? JunData))
                    {
                        ConsiderCandidates(juniors[j], JunData, juniorsWishlists[j]);
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
