using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SanayiGUIBackosffice.Messages;
using SanayiGUIBackosffice.Model;

namespace SanayiGUIBackosffice.Controllers
{
    [Route("api/[action]")]
    [ApiController]
    public class RobotController : ControllerBase
    {
        [HttpPost]
        public List<Movement> StartCommand (StartCommandRequestMessage requestMessage)
        {

            return new List<Movement> { };
        }
        [HttpPost]
        public void CollectTelemetry(CollectTelemetryRequestMessage requestMessage)
        {

        }
        [HttpPost]
        public void ObstacleState(ObstacleStateRequestMessage requestMessage)
        {

        }
        [HttpPost]
        public void SendQrInfo(SendQrInfoRequestMessage requestMessage)
        {

        }
        [HttpPost]
        public void CargoInfo(CargoInfoRequestMessage requestMessage)
        {

        }
        [HttpPost]
        public void MakeEmergencyBrake()
        {

        }
        [HttpPost]
        public void EmptyTour()
        {

        }
        [HttpPost]
        public void ManualControl(ManualControlRequestMessage requestMessage)
        {

        }
        [HttpPost]
        public void DrawObstacle(DrawObstacleRequestMessage requestMessage)
        {

        }
    }
}
