using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationBackend.Data;
using WebApplicationBackend.Model;

namespace WebApplicationBackend.Controllers
{
    public class ProductController : BaseApiController
    {
        private readonly ApplicationDbContext context;

        public ProductController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var product = await context.product.ToListAsync();
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            product.id = Guid.NewGuid();
            Console.WriteLine(product);
            await context.product.AddAsync(product);
            await context.SaveChangesAsync();

            return Ok(product);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetProduct([FromRoute] Guid id)
        {
            var product = await context.product.FirstOrDefaultAsync(x => x.id == id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] Guid id, Product updateProduct)
        {
            var product = await context.product.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            product.name = updateProduct.name;
            product.price = updateProduct.price;
            product.quantity = updateProduct.quantity;

            await context.SaveChangesAsync();

            return Ok(product);
        }
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] Guid id)
        {
            var product = await context.product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            context.product.Remove(product);
            await context.SaveChangesAsync();

            return Ok();
        }
    }
}
