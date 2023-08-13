using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bakery.Models
{
  public class Treat
  {
    public int TreatId { get; set; }
    // [Required(ErrorMessage = "The Treat's type can't be empty!")]
    public string Type { get; set; }
    
    public List<FlavorTreatEntity> FlavorTreatEntities{ get; set; }

  }

}