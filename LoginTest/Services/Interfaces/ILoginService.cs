using IsapiWSDL;

namespace LoginTest.Services.Interfaces
{
    public interface ILoginService
    {
        Task<LoginResponse> LoginWSDL(string username, string password);
    }
}
