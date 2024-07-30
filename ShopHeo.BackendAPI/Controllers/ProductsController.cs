using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopHeo.Application.Catalog.Products;
using ShopHeo.Data.Entities;
using ShopHeo.ViewModels.CataLog.Products;
using System.Threading.Tasks;

namespace ShopHeo.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public readonly IPublicProductService publicProductService;
        public readonly IManageProductService manageProductService;
        public ProductsController(IPublicProductService publicProductService, IManageProductService manageProductService)
        {
            this.publicProductService = publicProductService;
            this.manageProductService = manageProductService;
        }
        //http://localhost:port/products
        [HttpGet("languageId")]
        public async Task<IActionResult> Get(string languageId)
        {
            var produts = await this.publicProductService.GetAll(languageId);
            return Ok(produts);
        }
        //http://localhost:port/products/pubic-paging
        [HttpGet("public-paging/{languageId}")]
        public async Task<IActionResult> GetAllPaging([FromQuery]PagingGetManagerProductBase request)
        {
            var produts = await this.publicProductService.GetAllByCategoryId(request);
            return Ok(produts);
        }
        [HttpGet("{id}/{languageId}")]
        public async Task<IActionResult> GetById(int id, string languageId)
        {
            var produts = await this.manageProductService.GetById(id, languageId);
            if (produts == null)
            {
                return BadRequest("Cannot find product");
            }
            return Ok(produts);
        }
        //tao moi san phan
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm]ProductCreatedRequest request)
        {
          
            var productId = await this.manageProductService.Create(request);
            if (productId == 0)
                return BadRequest();

            var product = await this.manageProductService.GetById(productId, request.LanguageId);

            return CreatedAtAction(nameof(GetById), new { id = productId }, product);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] ProductUpdateRequest request)
        {
            var affectResult = await this.manageProductService.Update(request);
            if (affectResult == 0)
                return BadRequest();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var affectResult = await this.manageProductService.Delete(id);
            if (affectResult == 0)
                return BadRequest();
            return Ok();
        }
        [HttpPut("price/{id}/{newPrice}")]
        public async Task<IActionResult> UpdatePrice(int id, decimal newPrice)
        {
            var isSuccessful = await this.manageProductService.UpdatePrice(id, newPrice);
            if (isSuccessful)
                return Ok();

            return BadRequest();
        }
    }
}
