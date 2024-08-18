using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopHeo.Application.Catalog.Products;
using ShopHeo.Data.Entities;
using ShopHeo.ViewModels.CataLog.Products;
using ShopHeo.ViewModels.CataLog.ProductsImage;
using System.Threading.Tasks;

namespace ShopHeo.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        //http://localhost:port/products
        //http://localhost:port/products/pubic-paging
        [HttpGet("{languageId}")]
        public async Task<IActionResult> GetAllPaging(string languageId, [FromQuery]PagingGetPublicProductBase request)
        {
            var produts = await _productService.GetAllByCategoryId(languageId, request);
            return Ok(produts);
        }
        [HttpGet("{id}/{languageId}")]
        public async Task<IActionResult> GetById(int id, string languageId)
        {
            var produts = await _productService.GetById(id, languageId);
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
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var productId = await _productService.Create(request);
            if (productId == 0)
                return BadRequest();

            var product = await _productService.GetById(productId, request.LanguageId);

            return CreatedAtAction(nameof(GetById), new { id = productId }, product);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] ProductUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var affectResult = await _productService.Update(request);
            if (affectResult == 0)
                return BadRequest();
            return Ok();
        }
        [HttpDelete("{productID}")]
        public async Task<IActionResult> Delete(int productID)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var affectResult = await _productService.Delete(productID);
            if (affectResult == 0)
                return BadRequest();
            return Ok();
        }
        [HttpPatch("{productID}/{newPrice}")]
        public async Task<IActionResult> UpdatePrice(int productID, decimal newPrice)
        {
            var isSuccessful = await _productService.UpdatePrice(productID, newPrice);
            if (isSuccessful)
                return Ok();

            return BadRequest();
        }

        [HttpPost("{productId}/images")]
        public async Task<IActionResult> CreateImage(int productId,[FromForm] ProductImageCreatedRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var imageId = await _productService.AddImage(productId,request);
            if (imageId == 0)
                return BadRequest();

            var image = await _productService.GetImageId(imageId);

            return CreatedAtAction(nameof(GetImageId), new { id = imageId }, image);
        }

        [HttpGet("{productId}/images/{imageId}")]
        public async Task<IActionResult> GetImageId(int productId, int imageId)
        {
            var image = await _productService.GetImageId(imageId);
            if (image == null)
                return BadRequest("Cannot find product");
            return Ok(image);
        }

        [HttpPut("{productId}/images/{imageId}")]
        public async Task<IActionResult> UpdateImage(int imageId, [FromForm] ProductImageUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var Result = await _productService.UpdateImage(imageId,request);
            if (Result == 0)
                return BadRequest();
            return Ok();
        }

        [HttpDelete("{productID}/{images}/{imageId}")]
        public async Task<IActionResult> DeleteImage(int imageId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var affectResult = await _productService.Delete(imageId);
            if (affectResult == 0)
                return BadRequest();
            return Ok();
        }

    }
}
