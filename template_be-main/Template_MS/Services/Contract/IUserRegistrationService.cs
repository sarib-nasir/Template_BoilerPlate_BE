using Template_MS.Extensions;
using Template_MS.Models;
using Template_MS.Services.Base;
using Template_MS.ViewModels;

namespace Template_MS.Services.Contract
{
    public interface IUserRegistrationService : IService<UserLogin>
    {

        ApiResponse AddOrUpdatUserRegistration(UserRegistrationViewModel userRegistrationViewModel);
        ApiResponse GetUserRegistrationDetail(UserRegistrationViewModel model);
        ApiResponse DeleteUserDetail(ActiveViewModel model);


    }
}
