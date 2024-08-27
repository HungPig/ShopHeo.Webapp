using Microsoft.AspNetCore.Mvc;
using ShopHeo.ViewModels.Commom;
using System.Threading.Tasks;

namespace ShopHeo.AdminApp.Controllers.Components
{
    public class PagerViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(PageResultBase result)
        {
            return Task.FromResult((IViewComponentResult)View("Default", result));
        }
    }
}
