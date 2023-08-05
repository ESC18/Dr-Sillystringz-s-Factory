namespace Dr_Sillystringzs_Factory.Models
{
    public class Engineer
    {
        public int EngineerId { get; set; }

        public string Name { get; set; }
        public string Specialty { get; set; }
        public ICollection<EngineerMachine> EngineerMachines { get; set; }
    }
}

