using System.Threading.Tasks;

namespace AmplifierStarter.Domain.Authorization
{
    public interface ILoginManager
    {
        Task<LoginResult> LoginAsync(LoginInfo login);
    }
}