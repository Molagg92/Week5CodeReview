using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bakery.Models
{
  public class Flavor
  {
    public int FlavorId { get; set; }
    // [Required(ErrorMessage = "The Flavor's name can't be empty!")]
    public string Frosting { get; set; }
  
    public List<FlavorTreatEntity> FlavorTreatEntities { get; set; }
    
  }

}