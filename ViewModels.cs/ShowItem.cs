using System;

namespace NewMoodApi.ViewModels
{
  public class ShowItem
  {
    public int Id { get; set; }
    public string EventName { get; set; }
    public DateTime DateOfEvent { get; set; }

    public string VenueName { get; set; }
    public string VenueUrl { get; set; }
  }
}