using System;

namespace NewMoodApi.ViewModels
{
  public class NewShow
  {
    public string EventName { get; set; }
    public DateTime DateOfEvent { get; set; }

    public int VenueId { get; set; }
  }
}