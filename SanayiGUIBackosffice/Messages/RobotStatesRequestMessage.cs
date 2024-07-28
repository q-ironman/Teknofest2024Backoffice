namespace SanayiGUIWebApi.Messages
{
    public class RobotStatesRequestMessage
    {
        public bool IsMoving { get; set; }
        public bool Obstacle { get; set; }
        public bool IsLoaded { get; set; }
        public LedStates Leds{ get; set; } 
        public bool Fan { get; set; }
        public bool Emergency { get; set; }
    }
}
