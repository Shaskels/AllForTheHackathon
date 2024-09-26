namespace AllForTheHackathon
{
    public class HRDirector
    {
        private List<decimal> _harmonicMeans;
        public HRDirector()
        {
            _harmonicMeans = new List<decimal>();
        }

        public decimal CalculateTheHarmonicMean(List<Team> teams)
        {
            decimal sum = 0.0M;
            foreach (Team team in teams)
            {
                sum = sum +  1.0M / team.SatisfactionOfTeamLeader;
                sum = sum +  1.0M / team.SatisfactionOfJunior;
            }
            _harmonicMeans.Add(teams.Count * 2 / sum);
            return teams.Count * 2 / sum;
        }

        public decimal CalculateTheAverageValue()
        {
            decimal sum = 0.0M;
            foreach (decimal mean in _harmonicMeans)
            {
                sum += mean;
            }
            return sum / _harmonicMeans.Count;
        }
    }
}
