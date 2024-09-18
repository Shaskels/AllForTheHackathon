namespace AllForTheHackathon.Exeptions
{
    public class RegistrationException : Exception
    {
        public RegistrationException(string message)
            : base(message) { }
    }
}
