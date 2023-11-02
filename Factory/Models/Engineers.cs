using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Factory.Models
{
    public class EngineeringProfessional
    {
        public int EngineerId { get; set; }
        [Required(ErrorMessage = "The name field cannot be empty.")]
        public string Name { get; set; }
        public List<MachineEngineer> Collaborations { get; set; }
    }
}
