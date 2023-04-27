using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EcommerceAPI.Models;

namespace EcommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly EcommerceAPIDBContext _context;

        public ProductController(EcommerceAPIDBContext context)
        {
            _context = context;
        }

        // GET: api/Product
        // public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        [HttpGet]
        public async Task<ActionResult<Response>> GetProducts()
        {
            var response = new Response
            {
                statusCode = 404,
                statusDescription = "Error! No ProductS found.."
            };
            if (_context.Products == null)
            {
                return response;
            }

            var products = await _context.Products.ToListAsync();
            response.statusCode = 200;
            response.statusDescription = "Success! ProductS request was completed.";
            response.products = products;

            return response;
        }

        /*
            Bad Request = 400
            Not Found = 404;
            No content = 204;
            Success = 200;
         */
        // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> GetProduct(int id)
        {
            var response = new Response
            {
                statusCode = 404,
                statusDescription = "Error! No ProductS found.."
            };
            if (_context.Products == null)
            {
                return response;
            }

            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                response.statusDescription = "Error! No ProductS found matching given ID";
            }
            else
            {
                response.statusCode = 200;
                response.statusDescription = "Success! Product request was completed.";
                response.product = product;
            }

            return response;
        }

        // PUT: api/Product/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<Response>> PutProduct(int id, Product product)
        {
            var response = new Response();
            if (id != product.ProductId)
            {
                response.statusCode = 400;
                response.statusDescription = "Bad Request! " +
                    "input ID does not match Product's ID";
                return response;
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    response.statusCode = 404;
                    response.statusDescription = "Error! No ProductS found matching given ID";
                    return response;
                }
                else
                {
                    throw;
                }
            }

            response.statusCode = 204;
            response.statusDescription = "Content Successfully UPDATED at ID:" +
                id.ToString() + " with no response Body";
            return response;

            //return NoContent();
        }

        // POST: api/Product
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Response>> PostProduct(Product product)
        {
            var response = new Response
            {
                statusCode = 404,
                statusDescription = "Error! No ProductS found.."
            };

            if (_context.Products == null)
            {
                return response;
            }
            try
            {
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                response.statusCode = 200;
                response.statusDescription = "Success! New Product request completed.";
                response.product = product;
            }
            catch (Exception exception)
            {
                response.statusCode = 400;
                response.statusDescription = "Error! Incorrect Product input";
            }

            return response;

            //return CreatedAtAction("GetProduct", new { id = product.ProductId }, product);
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Response>> DeleteProduct(int id)
        {
            var response = new Response
            {
                statusCode = 404,
                statusDescription = "Error! No ProductS found.."
            };
            if (_context.Products == null)
            {
                return response;
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                response.statusDescription = "Error! No ProductS found matching given ID";
                return response;
            }

            // Remove product
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            response.statusCode = 204;
            response.statusDescription = "Content Successfully REMOVED at ID:" +
                id.ToString() + " with no response Body";
            return response;
        }

        private bool ProductExists(int id)
        {
            return (_context.Products?.Any(e => e.ProductId == id)).GetValueOrDefault();
        }
    }
}