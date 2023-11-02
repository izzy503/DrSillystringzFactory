namespace Factory.Models
{
  public class EngineeringMachineSpecialist
  {
    public int TechnicianMachineId { get; set; }
    public int MachineIdentifier { get; set; }
    public Machine Mechanism { get; set; }
    public int EngineerIdentifier { get; set; }
    public Engineer Specialist { get; set; }
  }
}
