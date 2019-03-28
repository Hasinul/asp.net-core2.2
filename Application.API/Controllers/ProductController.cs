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
        /// <summary>
        /// Get all Products.
        /// </summary>
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(ProductHelper.Get());
        }

        /// <summary>
        /// Get a specific Product.
        /// </summary>
        /// <param name="id"></param> 
        [HttpGet("{id}", Name = "Get")]
        public ActionResult Get(int id)
        {
            return Ok(ProductHelper.GetAProduct(id));
        }

        /// <summary>
        /// Creates a Product.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Product
        ///     {
        ///        "name": "Item1",
        ///        "description": "Good book";
        ///     }
        ///
        /// </remarks>
        [HttpPost]
        public ActionResult Post([FromBody] Product product)
        {
            return Ok(ProductHelper.AddProduct(product));
        }

        /// <summary>
        /// Update a specific Product.
        /// </summary>
        /// <param name="id"></param>       
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Product product)
        {
            return Ok(ProductHelper.Update(id, product));
        }

        /// <summary>
        /// Deletes a specific Product.
        /// </summary>
        /// <param name="id"></param>       
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(ProductHelper.DeleteProduct(id));
        }
    }
}
