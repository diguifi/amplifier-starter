using System.Threading.Tasks;

namespace AmplifierApiSample.Domain.Authorization
{
    public interface ILoginManager
    {
        Task<LoginResult> LoginAsync(LoginInfo login);
    }
}