using Server.Models;

namespace Server.Services
{
    public interface IAuthManager
    {
        Task<bool> ValidateUser(LoginDTO dto);
        Task<string> CreateToken();
    }
}
