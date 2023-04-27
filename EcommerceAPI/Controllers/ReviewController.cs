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
    public class ReviewController : ControllerBase
    {
        private readonly EcommerceAPIDBContext _context;

        public ReviewController(EcommerceAPIDBContext context)
        {
            _context = context;
        }

        // GET: api/Review
        // public async Task<ActionResult<IEnumerable<Review>>> GetReviews()
        [HttpGet]
        public async Task<ActionResult<Response>> GetReviews()
        {
            var response = new Response
            {
                statusCode = 404,
                statusDescription = "Error! No ReviewS found.."
            };
            if (_context.Reviews == null)
            {
                return response;
            }

            var reviews = await _context.Reviews.ToListAsync();
            response.statusCode = 200;
            response.statusDescription = "Success! ReviewS request was completed.";
            response.reviews = reviews;

            return response;
        }

        /*
            Bad Request = 400
            Not Found = 404;
            No content = 204;
            Success = 200;
         */
        // GET: api/Review/5
        // return list of reviews @ some productId
        [HttpGet("{productId}")]
        public async Task<ActionResult<Response>> GetReview(int productId)
        {
            var response = new Response
            {
                statusCode = 404,
                statusDescription = "Error! No ReviewS found.."
            };
            if (_context.Reviews == null)
            {
                return response;
            }

            List<Review> result = new List<Review>();
            // make list
            var DBreviews = await _context.Reviews.ToListAsync();

           
            foreach (Review review in DBreviews)
            {
                if(review.Product?.ProductId == productId) {
                    result.Append(review);
                }
            }

            //var review = await _context.Reviews.FindAsync(productId);

            // check if reviewsList null/empty
            if (!result.Any())
            {
                response.statusDescription = "Error! No ReviewS found matching given " +
                    "productID: " + productId.ToString();
            }
            else
            {
                response.statusCode = 200;
                response.statusDescription = "Success! Review request was completed.";
                response.reviews = result;
            }

            return response;
        }

        // PUT: api/Review/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{reviewId}")]
        public async Task<ActionResult<Response>> PutReview(int reviewId, Review review)
        {
            var response = new Response();
            if (reviewId != review.ReviewId)
            {
                response.statusCode = 400;
                response.statusDescription = "Bad Request! " +
                    "input ID does not match Review's ID";
                return response;
            }

            _context.Entry(review).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReviewExists(reviewId))
                {
                    response.statusCode = 404;
                    response.statusDescription = "Error! No ReviewS found at given" +
                        "reviewID: " + reviewId.ToString();
                    return response;
                }
                else
                {
                    throw;
                }
            }

            response.statusCode = 204;
            response.statusDescription = "Content Successfully UPDATED at ID:" +
                reviewId.ToString() + " with no response Body";
            return response;

            //return NoContent();
        }

        //
        // POST: api/Review
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Response>> PostReview(Review review)
        {
            var response = new Response
            {
                statusCode = 404,
                statusDescription = "Error! No ReviewS found.."
            };

            if (_context.Reviews == null)
            {
                return response;
            }
            try
            {
                _context.Reviews.Add(review);
                await _context.SaveChangesAsync();
                response.statusCode = 200;
                response.statusDescription = "Success! New Review request completed.";
                response.review = review;
            }
            catch (Exception exception)
            {
                response.statusCode = 400;
                response.statusDescription = "Error! Incorrect Review input";
            }

            return response;

            //return CreatedAtAction("GetReview", new { id = review.ReviewId }, review);
        }

        // Loop through list of reviews regardless of productID
        // DELETE: api/Review/5
        [HttpDelete("{reviewId}")]
        public async Task<ActionResult<Response>> DeleteReview(int reviewId)
        {
            var response = new Response
            {
                statusCode = 404,
                statusDescription = "Error! No ReviewS found.."
            };
            if (_context.Reviews == null)
            {
                return response;
            }

            var review = await _context.Reviews.FindAsync(reviewId);
            if (review == null)
            {
                response.statusDescription = "Error! No ReviewS found at given " +
                    "reviewId: " + reviewId.ToString();
                return response;
            }

            // Remove review
            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();

            response.statusCode = 204;
            response.statusDescription = "Content Successfully REMOVED at ID:" +
                reviewId.ToString() + " with no response Body";
            return response;
        }

        private bool ReviewExists(int id)
        {
            return (_context.Reviews?.Any(e => e.ReviewId == id)).GetValueOrDefault();
        }
    }
}
