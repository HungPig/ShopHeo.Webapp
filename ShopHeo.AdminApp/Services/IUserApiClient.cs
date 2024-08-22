using System;
using System.Collections.Generic;
using System.Linq;
using ShopHeo.ViewModels.CataLog.Users;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopHeo.ViewModels.Commom;

namespace ShopHeo.AdminApp.Service
{
    public interface IUserApiClient
    {
        Task<string> Authenticate(LoginRequest request);

        Task<PageResult<UserViewModel>> GetUserPagings(GetUserPagingRequest request);

        Task<bool> RegisterUser(RegisterRequest registerRequest);
    }
}
