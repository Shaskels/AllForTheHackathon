﻿namespace AllForTheHackathon.Domain
{
    public class HRDirector
    {
        private List<double> _harmonicMeans;
        public HRDirector()
        {
            _harmonicMeans = new List<double>();
        }

        public double CalculateTheHarmonicMean(List<Team> teams)
        {
            double sum = 0.0;
            foreach (Team team in teams)
            {
                sum = sum + 1.0 / team.SatisfactionOfTeamLeader;
                sum = sum + 1.0 / team.SatisfactionOfJunior;
            }
            _harmonicMeans.Add(teams.Count * 2 / sum);
            return teams.Count * 2 / sum;
        }

        public double CalculateTheAverageValue()
        {
            double sum = 0.0;
            foreach (double mean in _harmonicMeans)
            {
                sum += mean;
            }
            return sum / _harmonicMeans.Count;
        }

        public double CalculateTheAverageValue(List<Hackathon> hackathons)
        {
            double sum = 0.0;
            foreach (var hackathon in hackathons)
            {
                sum += hackathon.Result;
            }
            return sum / hackathons.Count;
        }
    }
}
