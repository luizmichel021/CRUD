

using CRUD_PRODUCTS.Models;
using CRUD_PRODUCTS.service;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_PRODUCTS.Controller
{
    [ApiController]
    [Route("api/products")]
    public class Controller : ControllerBase
    {
        private readonly Service _service;

        public Controller(Service service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }



        [HttpPost]
        public IActionResult Create(Product product)
        {
            int retId = _service.Create(product);
            
            if (retId == 0)
            {
                 return BadRequest(new { message = "[Controller] Fail to create product." });
            }
            return GetById(retId);
            
        }



        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {   
            var product = _service.GetById(id);
            if (product == null)
                return NotFound(new { message = "Produto não encontrado." });
            return Ok(product);
        }


        [HttpPut("{id}")]
        public IActionResult Update(Product product)
        {
           _service.Update(product);
            return Ok(GetById(product.Id));

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.DeleteProduct(id);
            return Ok();
        }
    }
}