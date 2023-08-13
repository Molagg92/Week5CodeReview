using System.Collections.Generic;
namespace Bakery.Models;

public class FlavorTreatEntity
{
   public int FlavorTreatEntityId { get; set; }
  public int FlavorId { get; set; }
  public Flavor Flavor { get; set; }
  public int TreatId { get; set; }
  public Treat Treat { get; set; }
}