namespace Dr_Sillystringzs_Factory.Models
{
    public class EngineerMachine
    {
        public int EngineerId { get; set; }
        public int MachineId { get; set; }
        public Engineer Engineer { get; set; }
        public Machine Machine { get; set; }
    }
}
