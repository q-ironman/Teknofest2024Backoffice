using Microsoft.AspNetCore.Mvc;
using SanayiGUIBackosffice.Messages;
using SanayiGUIBackosffice.Model;
using System.Text.Json;

namespace SanayiGUIBackosffice.Controllers
{
    [Route("api/[action]")]
    [ApiController]
    public class RobotController : ControllerBase
    {
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
        public void DrawObstacle(DrawObstacleRequestMessage requestMessage)
        {

        }
    }
}
