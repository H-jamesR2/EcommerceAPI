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
    public class DiscountController : ControllerBase
    {
        private readonly EcommerceAPIDBContext _context;

        public DiscountController(EcommerceAPIDBContext context)
        {
            _context = context;
        }

        // GET: api/Discount
        // public async Task<ActionResult<IEnumerable<Discount>>> GetDiscounts()
        [HttpGet]
        public async Task<ActionResult<Response>> GetDiscounts()
        {
            var response = new Response
            {
                statusCode = 404,
                statusDescription = "Error! No DiscountS found.."
            };
            if (_context.Discounts == null)
            {
                return response;
            }

            var discounts = await _context.Discounts.ToListAsync();
            response.statusCode = 200;
            response.statusDescription = "Success! DiscountS request was completed.";
            response.discounts = discounts;

            return response;
        }

        /*
            Bad Request = 400
            Not Found = 404;
            No content = 204;
            Success = 200;
         */
        // GET: api/Discount/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> GetDiscount(int id)
        {
            var response = new Response
            {
                statusCode = 404,
                statusDescription = "Error! No DiscountS found.."
            };
            if (_context.Discounts == null)
            {
                return response;
            }

            var discount = await _context.Discounts.FindAsync(id);

            if (discount == null)
            {
                response.statusDescription = "Error! No DiscountS found matching given ID";
            }
            else
            {
                response.statusCode = 200;
                response.statusDescription = "Success! Discount request was completed.";
                response.discount = discount;
            }

            return response;
        }

        // PUT: api/Discount/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<Response>> PutDiscount(int id, Discount discount)
        {
            var response = new Response();
            if (id != discount.DiscountId)
            {
                response.statusCode = 400;
                response.statusDescription = "Bad Request! " +
                    "input ID does not match Discount's ID";
                return response;
            }

            _context.Entry(discount).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiscountExists(id))
                {
                    response.statusCode = 404;
                    response.statusDescription = "Error! No DiscountS found matching given ID";
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

        // POST: api/Discount
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Response>> PostDiscount(Discount discount)
        {
            var response = new Response {
                statusCode = 404,
                statusDescription = "Error! No DiscountS found.."
            };

              if (_context.Discounts == null)
              {
                return response;
            }
            try
            {
                _context.Discounts.Add(discount);
                await _context.SaveChangesAsync();
                response.statusCode = 200;
                response.statusDescription = "Success! New Discount request completed.";
                response.discount = discount;
            } catch (Exception exception)
            {
                response.statusCode = 400;
                response.statusDescription = "Error! Incorrect Discount input";
            }

            return response;

            //return CreatedAtAction("GetDiscount", new { id = discount.DiscountId }, discount);
        }

        // DELETE: api/Discount/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Response>> DeleteDiscount(int id)
        {
            var response = new Response
            {
                statusCode = 404,
                statusDescription = "Error! No DiscountS found.."
            };
            if (_context.Discounts == null)
            {
                return response;
            }

            var discount = await _context.Discounts.FindAsync(id);
            if (discount == null)
            {
                response.statusDescription = "Error! No DiscountS found matching given ID";
                return response;
            }

            // Remove discount
            _context.Discounts.Remove(discount);
            await _context.SaveChangesAsync();

            response.statusCode = 204;
            response.statusDescription = "Content Successfully REMOVED at ID:" +
                id.ToString() + " with no response Body";
            return response;
        }

        private bool DiscountExists(int id)
        {
            return (_context.Discounts?.Any(e => e.DiscountId == id)).GetValueOrDefault();
        }
    }
}
