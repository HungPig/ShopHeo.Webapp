using ShopHeo.Application.Dtos;
using ShopHeo.ViewModels.CataLog.Users;
using ShopHeo.ViewModels.Commom;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopHeo.Application.System.User
{
    public interface IUserService
    {
        Task<string> Authencate(LoginRequest request);

        Task<bool> Register(RegisterRequest request);
    }
}
