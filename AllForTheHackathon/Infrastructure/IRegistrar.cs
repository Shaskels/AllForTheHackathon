namespace AllForTheHackathon.Infrastructure
{
    public interface IRegistrar
    {
        public List<T> RegisterParticipants<T>(string fileName);
    }
}
