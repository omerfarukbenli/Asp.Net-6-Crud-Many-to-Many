using Business.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
         private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<ActionResult> GetProducts([FromQuery] string searchTerm)
        {
            return Ok(await _productService.GetProducts(searchTerm));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetProductId(int id)
        {
            return Ok(await _productService.GetProductsID(id));
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAllProduct()
        {
            return Ok(await _productService.GetAllProduct());
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProductDto categoryDto)
        {
            return Ok(await _productService.Post(categoryDto));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateProductDto categoryDto)
        {

            return Ok(await _productService.Update(categoryDto, id));

        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {

            return Ok(await _productService.DeleteByIdAsync(id));

        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Post([FromBody] CreateandProductDto productDto)
        {
            return Ok(await _productService.AddProductCategory(productDto));
        }
    }
}
