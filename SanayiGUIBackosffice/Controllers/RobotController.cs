using Microsoft.AspNetCore.Mvc;
using SanayiGUIBackosffice.Messages;
using SanayiGUIBackosffice.Model;
using SanayiGUIWebApi.Messages;
using SanayiGUIWebApi.Utilites;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SanayiGUIBackosffice.Controllers
{
    [Route("api/[action]")]
    [ApiController]
    public class RobotController : ControllerBase
    {
        IWebSocketManager _webSocketManager;
        public static List<Point> Points { get; set; } = new List<Point>();

        public RobotController(IWebSocketManager webSocketManager)
        {
            _webSocketManager = webSocketManager;
        }

        [HttpPost]
        public async Task CollectTelemetry(CollectTelemetryRequestMessage requestMessage)
        {
            var uiMessage = new UiDataRequestMessage<CollectTelemetryRequestMessage> 
            {
                ClassType = nameof(CollectTelemetryRequestMessage),
                Data = requestMessage
            };
            var uiMessageJson = JsonSerializer.Serialize(uiMessage);
            await this._webSocketManager.BroadcastMessageAsync(uiMessageJson);
        }
        [HttpPost]
        public async Task ObstacleState(ObstacleStateRequestMessage requestMessage)
        {

        }
        [HttpPost]
        public async Task SendQrInfo(SendQrInfoRequestMessage requestMessage)
        {
            var uiMessage = new UiDataRequestMessage<SendQrInfoRequestMessage>
            {
                ClassType = nameof(SendQrInfoRequestMessage),
                Data = requestMessage
            };
            var uiMessageJson = JsonSerializer.Serialize(uiMessage);
            await this._webSocketManager.BroadcastMessageAsync(uiMessageJson);
        }

        //[HttpPost]
        //public async Task NewService(NewRequestMessage requestMessage)
        //{
        //    var uiMessage = new UiDataRequestMessage<NewRequestMessage>
        //    {
        //        ClassType = nameof(NewRequestMessage),
        //        Data = requestMessage
        //    };
        //    var uiMessageJson = JsonSerializer.Serialize(uiMessage);
        //    await this._webSocketManager.BroadcastMessageAsync(uiMessageJson);
        //}

        [HttpPost]
        public async Task CargoInfo(CargoInfoRequestMessage requestMessage)
        {

        }
        [HttpPost]
        public async Task SendPointCloud(List<Point> requestMessage)
        {

        }
        [HttpPost]
        public async Task RobotStates(RobotStatesRequestMessage requestMessage)
        {

        }
        [HttpPost]
        public async Task DrawObstacle(DrawObstacleRequestMessage requestMessage)
        {
            //for (var i = 5000; i <= 10000; i+=100)
            //{
            //    for (int ii = 0; ii < 100; ii++)
            //    {
            //        Points.Add(new Point
            //        {
            //            X = i+ii,
            //            Y = i,
            //        });
            //    }

            //    requestMessage.Points = Points;
            //    var uiMessage = new UiDataRequestMessage<DrawObstacleRequestMessage>
            //    {
            //        ClassType = nameof(DrawObstacleRequestMessage),
            //        Data = requestMessage
            //    };
            //    var uiMessageJson = JsonSerializer.Serialize(uiMessage);
            //    await this._webSocketManager.BroadcastMessageAsync(uiMessageJson);
            //    Thread.Sleep(5);
            //}
            Points.AddRange(requestMessage.Points);
            requestMessage.Points = Points;
            var uiMessage = new UiDataRequestMessage<DrawObstacleRequestMessage>
            {
                ClassType = nameof(DrawObstacleRequestMessage),
                Data = requestMessage
            };
            var uiMessageJson = JsonSerializer.Serialize(uiMessage);
            await this._webSocketManager.BroadcastMessageAsync(uiMessageJson);
        }
    }
}
