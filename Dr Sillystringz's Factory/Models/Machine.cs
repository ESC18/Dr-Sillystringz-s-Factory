using System.Collections.Generic;

namespace Dr_Sillystringzs_Factory.Models
{
    public class Machine
    {
        public int MachineId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<EngineerMachine> EngineerMachines { get; set; }
    }
}
