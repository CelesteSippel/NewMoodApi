using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewMoodApi.Models;
using NewMoodApi.ViewModels;

namespace NewMoodApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ShowController : ControllerBase
  {
    private readonly DatabaseContext _context;

    public ShowController(DatabaseContext context)
    {
      _context = context;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<Show>>> GetShows()
    {
      var db = new DatabaseContext();
      var results = db.Shows.Include(i => i.Venue);
      var rv = results.Select(show => new ShowItem
      {
        Id = show.Id,
        EventName = show.EventName,
        DateOfEvent = show.DateOfEvent,
        VenueName = show.Venue.VenueName,
        VenueUrl = show.Venue.VenueUrl
      });

      return Ok(rv);
    }




    [HttpGet("{id}")]
    public async Task<ActionResult<Show>> GetShow(int id)
    {
      var show = await _context.Shows.FindAsync(id);

      if (show == null)
      {
        return NotFound();
      }

      return show;
    }

    // PUT: api/Show/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for
    // more details see https://aka.ms/RazorPagesCRUD.
    [HttpPut("{id}")]
    public async Task<IActionResult> PutShow(int id, Show show)
    {
      if (id != show.Id)
      {
        return BadRequest();
      }

      _context.Entry(show).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ShowExists(id))
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
    public async Task<ActionResult<Show>> CreatedShow(NewShow vm)
    {
      var db = new DatabaseContext();
      var venue = db.Venues
        .FirstOrDefault(venue => venue.Id == vm.VenueId);
      if (venue == null)
      {
        return NotFound();
      }
      else
      {
        var show = new Show
        {
          EventName = vm.EventName,
          DateOfEvent = vm.DateOfEvent,
          VenueId = vm.VenueId

        };
        db.Shows.Add(show);
        db.SaveChanges();
        var rv = new CreatedShow
        {
          Id = show.Id,
          EventName = show.EventName,
          DateOfEvent = show.DateOfEvent,
          VenueId = show.VenueId

        };
        return Ok(rv);
      }
    }

    private bool ShowExists(int id)
    {
      return _context.Shows.Any(e => e.Id == id);
    }
  }
}