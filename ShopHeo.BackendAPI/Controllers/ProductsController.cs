using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopHeo.Application.Catalog.Products;
using System.Threading.Tasks;

namespace ShopHeo.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public readonly IPublicProductService publicProductService;
        public ProductsController(IPublicProductService publicProductService)
        {
            this.publicProductService = publicProductService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var produts = await this.publicProductService.GetAll();
            return Ok(produts);
        }
    }
}
