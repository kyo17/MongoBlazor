using System;
using System.Threading.Tasks;
using Collections;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ProductController : Controller
    {
        private IProduct repo = new ProductCollection();

        [HttpGet]
        public async Task<IActionResult> getAll()
        {
            return Ok(await repo.getAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getOneById(string id)
        {
            return Ok(await repo.getOneById(id));
        }

        [HttpPost]
        public async Task<IActionResult> insert([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            await repo.save(product);
            return Created("Creado", true);
        }

        [HttpDelete]
        public async Task<IActionResult> remove(string id)
        {
            await repo.delete(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> update([FromBody] Product product, string id)
        {
            id = product.Id;

            await repo.save(product);
            return Created("Modificado", true);
        }
    }
}
