using System;
using System.Collections.Generic;

namespace NewMoodApi.Models
{
  public class Booking
  {

    public int Id { get; set; }
    public string ContactName { get; set; }

    public string Email { get; set; }

    public DateTime EventDate { get; set; }

    public string EventLocation { get; set; }

    public string EventDetails { get; set; }




  }
}