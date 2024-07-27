namespace SanayiGUIWebApi.Messages
{
    public class ControlPanelRequestMessage
    {
        public bool InnerLedActive { get; set; }
        public bool OuterLedActive { get; set; }
        public bool FanActive { get; set; }
    }
}
