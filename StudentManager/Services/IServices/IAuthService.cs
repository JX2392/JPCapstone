using StudentManager.Models.Dto;

namespace StudentManager.Services.IServices
{
    public interface IAuthService
    {
        Task<T> LoginAsync<T>(LoginRequestDTO loginRequestDTO);

        Task<T> RegisterAsync<T>(RegisterationRequestDTO registerationRequestDTO);
    }
}
