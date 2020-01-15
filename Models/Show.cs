using System;


namespace NewMoodApi.Models
{
  public class Show
  {

    public int Id { get; set; }
    public string EventName { get; set; }

    public DateTime DateOfEvent { get; set; }


    public int VenueId { get; set; }

    public Venue Venue { get; set; }


  }
}