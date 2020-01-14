using System;
using System.Collections.Generic;

namespace NewMoodApi.Models
{
  public class Show
  {

    public int Id { get; set; }
    public string EventName { get; set; }

    public DateTime DateOfEvent { get; set; }
    public string StreetAddress { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Zip { get; set; }




  }
}