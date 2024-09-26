using AllForTheHackathon.Exсeptions;

namespace AllForTheHackathon
{
    public class RegistrarFromCSVFiles : IRegistrar
    {
        private void Register<T>(string file, List<T> participants)
        {
            if (File.Exists(file))
            {
                using (StreamReader textFile = new StreamReader(file))
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
                if (participants.Count != Constants.NumberOfTeams)
                {
                    IsRegistrationSuccess.IsSuccess = false;
                }
            }
        }

        public List<T> RegisterParticipants<T>(string fileName)
        {
            List<T> participants = new List<T>();
            Register<T>(fileName, participants);
            return participants;
        }
    }
}
