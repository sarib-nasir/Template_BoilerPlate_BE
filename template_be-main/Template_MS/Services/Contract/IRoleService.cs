using Template_MS.Extensions;
using Template_MS.Models;
using Template_MS.Services.Base;
using Template_MS.ViewModels;

namespace Template_MS.Services.Contract
{
    public interface IRoleService : IService<UserRole>
    {
        ApiResponse GetRoleDetail(UserRoleViewModel model);
        ApiResponse AddOrUpdateRole(UserRoleViewModel model);
        ApiResponse DeleteRoleDetail(UserRoleViewModel model);
    }
}
