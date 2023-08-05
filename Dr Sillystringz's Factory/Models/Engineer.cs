using System.Collections.Generic;

namespace Dr_Sillystringzs_Factory.Models
{
    public class Engineer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LicenseNumber { get; set; }
        public ICollection<EngineerMachine> EngineerMachines { get; set; }
    }
}
