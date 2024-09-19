namespace AllForTheHackathon.Exсeptions
{
    public class RegistrationException : Exception
    {
        public RegistrationException(string message)
            : base(message) { }
    }
}
