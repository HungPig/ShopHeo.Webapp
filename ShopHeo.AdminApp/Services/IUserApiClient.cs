using System;
using System.Collections.Generic;
using System.Linq;
using ShopHeo.ViewModels.CataLog.Users;
using System.Threading.Tasks;

namespace ShopHeo.AdminApp.Service
{
    public interface IUserApiClient
    {
        Task<string> Authenticate(LoginRequest request);
    }
}
