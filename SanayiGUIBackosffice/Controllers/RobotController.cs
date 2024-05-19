﻿using Microsoft.AspNetCore.Mvc;
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
        public List<Movement> StartCommand(StartCommandRequestMessage requestMessage)
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
        public async Task ManualControl(ManualControlRequestMessage requestMessage)
        {
            var robotUrl = "http://192.168.1.1:80/api/ManualControl";
            var client = new HttpClient();
            var content = new StringContent(JsonSerializer.Serialize<ManualControlRequestMessage>(requestMessage), System.Text.Encoding.UTF8, "application/json");
            var res = await client.PostAsync(robotUrl, content);


        }
        [HttpPost]
        public void DrawObstacle(DrawObstacleRequestMessage requestMessage)
        {

        }
    }
}
