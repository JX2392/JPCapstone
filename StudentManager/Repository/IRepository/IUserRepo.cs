using StudentManager.Models;
using StudentManager.Models.DTO;

namespace StudentManager.Repository.IRepository
{
    public interface IUserRepo
    {
        bool IsUniqueUser(string username);
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
        Task<LocalUser> Register(RegisterationRequestDTO registerationRequestDTO);
    }
}
