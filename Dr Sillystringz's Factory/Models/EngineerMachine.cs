namespace Dr_Sillystringz_s_Factory.Models
{
    public class EngineerMachine
    {
        public int EngineerId { get; set; }
        public Engineer Engineer { get; set; }

        public int MachineId { get; set; }
        public Machine Machine { get; set; }
    }
}
