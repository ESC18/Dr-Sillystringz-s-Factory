using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dr_Sillystringz_s_Factory.Models
{
    public class Machine
    {
        public int MachineId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Manufacturer is required.")]
        public string Manufacturer { get; set; }

        [DataType(DataType.Date)]
        public DateTime? InstallationDate { get; set; }

        public ICollection<EngineerMachine> EngineerMachines { get; set; }
    }
}
