using SanayiGUIBackosffice.Model;

namespace SanayiGUIBackosffice.Messages
{
    public class CollectTelemetryRequestMessage
    {
        public BatteryTelemetry BatteryTelemetry { get; set; }
        public CarTelemetry CarTelemetry { get; set; }
        public MotorTelemetry MotorTelemetry { get; set; }
        public HeatTelemetry HeatTelemetry { get; set; }
    }
}
