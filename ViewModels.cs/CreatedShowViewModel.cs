using System;

namespace NewMoodApi.ViewModels
{
  public class CreatedShow
  {
    public int Id { get; set; }
    public string EventName { get; set; }
    public DateTime DateOfEvent { get; set; }

    public int VenueId { get; set; }
  }
}