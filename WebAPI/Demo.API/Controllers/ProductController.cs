using Demo.API.Data;
using Demo.API.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo.API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DemoDbContext _demoDbContext;

        public ProductController(DemoDbContext demoDbContext) => _demoDbContext = demoDbContext;

        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get() { return _demoDbContext.Products; }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Product?>> GetById(int Id)
        {
            return _demoDbContext.Products.Where(x => x.Id == Id).FirstOrDefault();
        }

        [HttpPost]
        public async Task<ActionResult> Create (Product product) 
        { 
            await _demoDbContext.Products.AddAsync(product);
            await _demoDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new {id = product.Id}, product);
        }

        [HttpPut]
        public async Task<ActionResult> Update(Product product)
        {
            _demoDbContext.Products.Update(product);
            await _demoDbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var productGetByIdResult = await GetById(id);
            if (productGetByIdResult.Value is null)
                return NotFound();

            _demoDbContext.Remove(productGetByIdResult.Value);
            await _demoDbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
