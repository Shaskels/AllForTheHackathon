using AllForTheHackathon.Domain;
using AllForTheHackathon.Infrastructure.IsSuccess;
using Microsoft.Extensions.Options;

namespace AllForTheHackathon.Infrastructure
{
    public class RegistrarFromCSVFiles : IRegistrar
    {
        private Settings _constants;
        public RegistrarFromCSVFiles(IOptions<Settings> consts)
        {
            _constants = consts.Value;
        }
        private void Register<T>(string file, List<T> participants)
        {
            if (File.Exists("./Resources/" + file))
            {
                using (StreamReader textFile = new StreamReader("./Resources/" + file))
                {
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
                            IsRegistrationSuccess.IsSuccess = false;
                        }
                    }
                }
                if (participants.Count != _constants.NumberOfTeams)
                {
                    IsRegistrationSuccess.IsSuccess = false;
                }
            }
        }

        public List<T> RegisterParticipants<T>(string fileName)
        {
            List<T> participants = new List<T>();
            Register(fileName, participants);
            return participants;
        }
    }
}
