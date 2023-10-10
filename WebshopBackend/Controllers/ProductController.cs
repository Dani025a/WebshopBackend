using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebshopBackend.Data;
using WebshopBackend.Dto;
using WebshopBackend.Interfaces;
using WebshopBackend.Models;
using WebshopBackend.Repository;

namespace WebshopBackend.Controllers
{
        [Route("api/products")]
        [ApiController]
        public class ProductController : ControllerBase
        {
        private readonly IProductRepository _productRepository;
            private readonly IMapper _mapper;

            public ProductController(IProductRepository productRepository,
                IMapper mapper)
            {
                _productRepository = productRepository;
                _mapper = mapper;
            }

        // GET: api/products
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<ProductDto>))]
        [ProducesResponseType(400)]
        public IActionResult GetProducts([FromQuery] int? categoryid)
        {
            List<ProductDto> products;

            if (categoryid.HasValue)
            {
                products = _mapper.Map<List<ProductDto>>(_productRepository.GetProductsFromCategory(categoryid.Value));
            }
            else
            {
                products = _mapper.Map<List<ProductDto>>(_productRepository.GetProducts());
            }

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(products);
        }


        [HttpPost]
            [ProducesResponseType(204)]
            [ProducesResponseType(400)]
            public IActionResult CreateProduct([FromBody] Product productCreate)
            {
                if (productCreate == null)
                    return BadRequest(ModelState);


                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var productMap = _mapper.Map<Product>(productCreate);


                if (!_productRepository.CreateProduct(productMap))
                {
                    ModelState.AddModelError("", "Something went wrong while saving");
                    return StatusCode(500, ModelState);
                }

                return Ok("Successfully created");
            }

            [HttpPut("{productid}")]
            [ProducesResponseType(400)]
            [ProducesResponseType(204)]
            [ProducesResponseType(404)]
            public IActionResult UpdateProduct(int productid, [FromBody] ProductDto updatedProduct)
            {
                if (updatedProduct == null)
                    return BadRequest(ModelState);

                if (productid != updatedProduct.ProductId)
                    return BadRequest(ModelState);

                if (!_productRepository.ProductExists(productid))
                    return NotFound();

                if (!ModelState.IsValid)
                    return BadRequest();

                var productMap = _mapper.Map<Product>(updatedProduct);

                if (!_productRepository.UpdateProduct(productMap))
                {
                    ModelState.AddModelError("", "Something went wrong updating product");
                    return StatusCode(500, ModelState);
                }

                return NoContent();
            }

            [HttpDelete("{productid}")]
            [ProducesResponseType(400)]
            [ProducesResponseType(204)]
            [ProducesResponseType(404)]
            public IActionResult DeleteProduct(int productid)
            {
                if (!_productRepository.ProductExists(productid))
                {
                    return NotFound();
                }

                var productToDelete = _productRepository.GetProduct(productid);

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (!_productRepository.DeleteProduct(productToDelete))
                {
                    ModelState.AddModelError("", "Something went wrong deleting product");
                }

                return NoContent();
            }
        }
    }