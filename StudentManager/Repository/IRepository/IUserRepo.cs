using StudentManager.Models;
using StudentManager.Models.Dto;
namespace StudentManager.Repository.IRepository
{
    public interface IUserRepo
    {
        bool IsUniqueUser(string username);
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
        Task<LocalUser> Register(RegisterationRequestDTO registerationRequestDTO);
    }
}
