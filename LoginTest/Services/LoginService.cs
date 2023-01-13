using IsapiWSDL;
using LoginTest.Services.Interfaces;

namespace LoginTest.Services
{
    public class LoginService : ILoginService
    {
        public async Task<LoginResponse> LoginWSDL(string username, string password)
        {
            ICUTechClient client = new ICUTechClient();
            return await client.LoginAsync(username, password, ""); ;
        }
    }
}
