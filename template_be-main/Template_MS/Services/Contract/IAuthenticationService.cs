using Template_MS.Extensions;
using Template_MS.Models;
using Template_MS.Services.Base;
using Template_MS.ViewModels;
using System.Threading.Tasks;

namespace Template_MS.Services.Contract
{
    public interface IAuthenticationService : IService<UserLogin>
    {
        Task<ApiResponse> Authenticate(LoginViewModel obj);

    }
}
