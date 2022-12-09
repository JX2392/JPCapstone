using Utility;
using StudentManager.Models;
using StudentManager.Models.Dto;
using StudentManager.Services.IServices;

namespace StudentManager.Services
{
    public class AuthService : BaseService, IAuthService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string studentUrl;

        public AuthService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            studentUrl = configuration.GetValue<string>("ServiceUrls:StudentManagerAPI");

        }

        public Task<T> LoginAsync<T>(LoginRequestDTO loginRequestDTO)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = loginRequestDTO,
                Url = studentUrl + "/api/User/login",
            });
        }

        public Task<T> RegisterAsync<T>(RegisterationRequestDTO registerationRequestDTO)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = registerationRequestDTO,
                Url = studentUrl + "/api/User/register",
            });
        }
    }
}
