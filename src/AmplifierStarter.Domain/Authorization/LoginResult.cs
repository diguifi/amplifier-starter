namespace AmplifierStarter.Domain.Authorization
{
    public class LoginResult
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public User User { get; set; }
    }
}
