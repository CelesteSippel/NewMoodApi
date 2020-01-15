using System.Collections.Generic;
using Newtonsoft.Json;

namespace NewMoodApi.Models
{
  public class Venue
  {

    public int Id { get; set; }
    public string VenueName { get; set; }

    public string VenueUrl { get; set; }
    public string StreetAddress { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Zip { get; set; }

    [JsonIgnore]
    public List<Show> Shows { get; set; }
          = new List<Show>();


  }
}