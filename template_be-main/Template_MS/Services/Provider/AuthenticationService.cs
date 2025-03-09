using Template_MS.Extensions;
using Template_MS.Models;
using Template_MS.Services.Base;
using Template_MS.Services.Contract;
using Template_MS.ViewModels;
using System;
using System.Threading.Tasks;

namespace Template_MS.Services.Provider
{
    public class AuthenticationService : Service<UserLogin>, IAuthenticationService
    {
        private ApiResponse _apiResponse;
        public AuthenticationService()
        {
            _apiResponse = new ApiResponse();
        }

        public async Task<ApiResponse> Authenticate(LoginViewModel obj)
        {
            CustomLogger.Debug("========= START Authenticate() ===========");
            try
            {
                
                var userDetail = GetFirst(x => x.UserName.ToUpper() == obj.Email.ToUpper() && x.isActive == true, x => x.UserRole);
                if (userDetail != null)
                {
                    _apiResponse.Token = TokenManager.GenerateToken(userDetail);
                    _apiResponse.message = "User Login Successfully.";
                    _apiResponse.statusCode = "00";
                }
                else
                {
                     _apiResponse.message = "Unable to connect with user";                   
                }
            }
            catch (Exception ex)
            {

                CustomLogger.WriteErrorLogToFile(ex);
            }

            return _apiResponse;
        }
    }
}
