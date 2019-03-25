using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        // GET: api/Product
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(ProductHelper.Get());
        }

        // GET: api/Product/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult Get(int id)
        {
            return Ok(ProductHelper.GetAProduct(id));
        }

        // POST: api/Product
        [HttpPost]
        public ActionResult Post([FromBody] Product product)
        {
            return Ok(ProductHelper.AddProduct(product));
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Product product)
        {
            return Ok(ProductHelper.Update(id, product));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(ProductHelper.DeleteProduct(id));
        }
    }
}
