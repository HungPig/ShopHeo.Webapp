using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopHeo.ViewModels.Commom;
using ShopHeo.ViewModels.System.Users;

namespace ShopHeo.AdminApp.Service
{
    public interface IUserApiClient
    {
        Task<ApiResult<string>> Authenticate(LoginRequest request);

        Task<ApiResult<PageResult<UserViewModel>>> GetUserPagings(GetUserPagingRequest request);

        Task<ApiResult<bool>> RegisterUser(RegisterRequest registerRequest);
        Task<ApiResult<bool>> UpdateUser(Guid id,UserUpdateRequest updateRequest);

        Task<ApiResult<UserViewModel>> GetById(Guid id);

        Task<ApiResult<bool>> DeleteUser(Guid id);
    }
}
