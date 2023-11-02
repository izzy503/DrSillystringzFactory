using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Factory.Models
{
  public class MachineUnit
  {
    public int DeviceId { get; set; }

    [Required(ErrorMessage = "Machine name is required")]
    public string Title { get; set; }

    public List<MachineEngineer> Collaborations { get; set; }
  }
}
