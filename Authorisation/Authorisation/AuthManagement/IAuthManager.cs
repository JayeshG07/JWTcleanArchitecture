using Domain.Dto;

namespace Authorisation.Authorisation.AuthManagement
{
    public interface IAuthManager
    {
        Task<bool> RegisterUser(RegisterUserDto userDto);
        Task<string> Login(LoginDto loginDto);
    }
}
