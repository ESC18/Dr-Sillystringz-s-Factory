﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dr_Sillystringz_s_Factory.Models
{
    public class Engineer
    {
        public int EngineerId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Specialty is required.")]
        public string Specialty { get; set; }
    
        public ICollection<EngineerMachine> EngineerMachines { get; set; }
    }
}
