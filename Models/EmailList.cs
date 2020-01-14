using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NewMoodApi.Models
{
  public class EmailList
  {
    public int Id { get; set; }

    [Required]
    public string Email { get; set; }





  }
}