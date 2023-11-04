using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Factory.Models
{
  public class Machine
  {
    public int MachineId { get; set; }

    [Required(ErrorMessage = "Machine name is required")]
    public string Title { get; set; }

    public List<MachineEngineer> Collaborations { get; set; }
  }
}
