namespace Dr_Sillystringz_s_Factory.Models
{
    public class Machine
    {
        public int MachineId { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public DateTime InstallationDate { get; set; }
        public ICollection<EngineerMachine> EngineerMachines { get; set; }
    }
}
