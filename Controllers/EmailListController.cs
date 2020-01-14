using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewMoodApi.Models;

namespace NewMoodApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailListController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public EmailListController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/EmailList
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmailList>>> GetEmailLists()
        {
            return await _context.EmailLists.ToListAsync();
        }

        // GET: api/EmailList/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmailList>> GetEmailList(int id)
        {
            var emailList = await _context.EmailLists.FindAsync(id);

            if (emailList == null)
            {
                return NotFound();
            }

            return emailList;
        }

        // PUT: api/EmailList/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmailList(int id, EmailList emailList)
        {
            if (id != emailList.Id)
            {
                return BadRequest();
            }

            _context.Entry(emailList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmailListExists(id))
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

        // POST: api/EmailList
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<EmailList>> PostEmailList(EmailList emailList)
        {
            _context.EmailLists.Add(emailList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmailList", new { id = emailList.Id }, emailList);
        }

        // DELETE: api/EmailList/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmailList>> DeleteEmailList(int id)
        {
            var emailList = await _context.EmailLists.FindAsync(id);
            if (emailList == null)
            {
                return NotFound();
            }

            _context.EmailLists.Remove(emailList);
            await _context.SaveChangesAsync();

            return emailList;
        }

        private bool EmailListExists(int id)
        {
            return _context.EmailLists.Any(e => e.Id == id);
        }
    }
}
