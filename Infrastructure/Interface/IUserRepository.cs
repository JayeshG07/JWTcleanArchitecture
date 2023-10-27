using Domain.Dto;

namespace Infrastructure.Interface
{
    public interface IUserRepository
    {
        public Task<UserDto> UpdateUserAsync(UserDto userDto);
    }
}
