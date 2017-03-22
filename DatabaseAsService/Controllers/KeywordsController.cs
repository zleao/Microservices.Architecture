using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DatabaseAsService.Data;
using DatabaseAsService.Models;

namespace DatabaseAsService.Controllers
{
    [Produces("application/json")]
    [Route("api/Keywords")]
    public class KeywordsController : Controller
    {
        private readonly DatabaseAsServiceContext _context;

        public KeywordsController(DatabaseAsServiceContext context)
        {
            _context = context;
        }

        // GET: api/Keywords
        [HttpGet]
        public IEnumerable<Keyword> GetKeywords()
        {
            return _context.Keywords;
        }

        // GET: api/Keywords/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetKeyword([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var keyword = await _context.Keywords.SingleOrDefaultAsync(m => m.Id == id);

            if (keyword == null)
            {
                return NotFound();
            }

            return Ok(keyword);
        }

        // PUT: api/Keywords/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKeyword([FromRoute] int id, [FromBody] Keyword keyword)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != keyword.Id)
            {
                return BadRequest();
            }

            _context.Entry(keyword).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KeywordExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Keywords
        [HttpPost]
        public async Task<IActionResult> PostKeyword([FromBody] Keyword keyword)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Keywords.Add(keyword);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKeyword", new { id = keyword.Id }, keyword);
        }

        // DELETE: api/Keywords/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKeyword([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var keyword = await _context.Keywords.SingleOrDefaultAsync(m => m.Id == id);
            if (keyword == null)
            {
                return NotFound();
            }

            _context.Keywords.Remove(keyword);
            await _context.SaveChangesAsync();

            return Ok(keyword);
        }

        private bool KeywordExists(int id)
        {
            return _context.Keywords.Any(e => e.Id == id);
        }
    }
}