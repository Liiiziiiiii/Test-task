using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using site_testing.Model;

namespace site_testing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompletedTestsController : ControllerBase
    {
        private readonly TestContext _context;

        public CompletedTestsController(TestContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompletedTest>>> GetcompletedTest()
        {
            return await _context.completedTest.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompletedTest>> GetCompletedTest(int id)
        {
            var completedTest = await _context.completedTest.FindAsync(id);

            if (completedTest == null)
            {
                return NotFound();
            }

            return completedTest;
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompletedTest(int id, CompletedTest completedTest)
        {
            if (id != completedTest.IdCompletedTest)
            {
                return BadRequest();
            }

            _context.Entry(completedTest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompletedTestExists(id))
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

        [HttpPost]
        public async Task<ActionResult<CompletedTest>> PostCompletedTest(int testId, int userId)
        {
            var test = await _context.test.FindAsync(testId);
            var user = await _context.user.FindAsync(userId);

            if (test == null || user == null)
            {
                return BadRequest("Invalid test ID or user ID.");
            }

            var completedTest = new CompletedTest
            {
                Test = test,
                User = user
            };
            _context.completedTest.Add(completedTest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompletedTest", new { id = completedTest.IdCompletedTest }, completedTest);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompletedTest(int id)
        {
            var completedTest = await _context.completedTest.FindAsync(id);
            if (completedTest == null)
            {
                return NotFound();
            }

            _context.completedTest.Remove(completedTest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompletedTestExists(int id)
        {
            return _context.completedTest.Any(e => e.IdCompletedTest == id);
        }
    }
}
