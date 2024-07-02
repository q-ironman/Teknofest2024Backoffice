namespace SanayiGUIBackosffice.Messages
{
    public class StartCommandRequestMessage
    {
        public string Direction { get; set; }
        public List<Command> Command { get; set; }
    }

    public class Command
    {
        public string Label { get; set; }
        public string Value { get; set; }
    }
}
