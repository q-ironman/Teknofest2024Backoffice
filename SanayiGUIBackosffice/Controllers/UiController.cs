using MapManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SanayiGUIBackosffice.Messages;
using SanayiGUIBackosffice.Model;
using SanayiGUIWebApi.Messages;
using System.Text;
using System.Text.Json;

namespace SanayiGUIWebApi.Controllers
{
    [Route("api/[action]")]
    [ApiController]
    public class UiController : ControllerBase
    {
        private readonly RouteManager routeManager;
        public record SendStartCommandRequestMessage(List<string> LoadingNode, List<string> UnloadingNode, List<string> Command, string Direction);
        public static Dictionary<string, List<string>> EmptyTourRoutes = new Dictionary<string, List<string>> {
            {"Q22R",new List<string>{ "Q22","Q23","Q24","Q25","Q26","Q27","Q28","Q29","Q30","Q1","Q2","Q3","Q4","Q5","Q6","Q7","Q8","Q9","Q10","Q11", "Q12","Q13","Q14","Q15","Q16","Q17","Q18","Q19","Q20","Q21","Q22" } },
            {"S22L",new List<string>{ "Q22", "Q21","Q20","Q19","Q18","Q17","Q16","Q15","Q14","Q13","Q12","Q11","Q10","Q9","Q8","Q7","Q6","Q5","Q4","Q3","Q2","Q1","Q30","Q29","Q28","Q27","Q26","Q25","Q24","Q23","Q22"} },
            {"Q7R",new List<string>{ "Q7", "Q6", "Q5", "Q4", "Q3", "Q2", "Q1", "Q30", "Q29", "Q28", "Q27", "Q26", "Q25", "Q24", "Q23", "Q22", "Q21", "Q20", "Q19", "Q18", "Q17", "Q16", "Q15", "Q14", "Q13", "Q12", "Q11", "Q10", "Q9", "Q8", "Q7"} },
            {"Q7L",new List<string>{ "Q7", "Q8", "Q9", "Q10", "Q11", "Q12", "Q13", "Q14", "Q15", "Q16", "Q17", "Q18", "Q19", "Q20", "Q21", "Q22", "Q23", "Q24", "Q25", "Q26", "Q27", "Q28", "Q29", "Q30", "Q1", "Q2", "Q3" ,"Q4", "Q5", "Q6", "Q7"} }
        };
        public UiController(RouteManager routeManager)
        {
            this.routeManager = routeManager;
        }
        [HttpPost]
        public async Task<List<string>> StartCommand(StartCommandRequestMessage requestMessage)
        {
            List<string> shortestPath = new();
            var commandList = requestMessage.Command;
            for (int i = 0; i < commandList.Count - 1; i++)
            {
                var startLabel = commandList[i].Value;
                var endLabel = commandList[i + 1].Value;
                var pathPart = routeManager.GetShortestPath(startLabel, endLabel);
                shortestPath.AddRange(pathPart);
            }
            var startCommandRequestMessage = new SendStartCommandRequestMessage(requestMessage.LoadingNode, requestMessage.UnloadingNode, shortestPath, requestMessage.Direction);

            var robotUrl = "http://localhost:80/api/ManualControl";
            var client = new HttpClient();
            var content = new StringContent(JsonSerializer.Serialize(startCommandRequestMessage), Encoding.UTF8, "application/json");
            try
            {
                var res = await client.PostAsync(robotUrl, content);
            }
            catch (Exception)
            {
            }

            return shortestPath;
        }

        [HttpGet]
        public async Task MakeEmergencyBrake()
        {
            var robotUrl = "http://localhost:80/api/MakeEmergencyBrake";
            var client = new HttpClient();
            var res = await client.GetAsync(robotUrl);
        }
        [HttpGet]
        public async Task CancelEmergency()
        {
            var robotUrl = "http://localhost:80/api/CancelEmergency";
            var client = new HttpClient();
            var res = await client.GetAsync(robotUrl);
        }
        [HttpPost]
        public async Task EmptyTour(EmptyTourRequestMessage requestMessage)
        {
            if (requestMessage is null || requestMessage.StartPoint is null || requestMessage.Direction is null)
            {
                return;
            }
            var key = $"{requestMessage.StartPoint}{requestMessage.Direction}";
            var routeInfo = EmptyTourRoutes.TryGetValue(key, out var result);
            var startCommandMessage = new SendStartCommandRequestMessage(new(), new(), result, null);
            var robotUrl = "http://localhost:80/api/EmptyTour";
            var client = new HttpClient();
            var content = new StringContent(JsonSerializer.Serialize(startCommandMessage), Encoding.UTF8, "application/json");
            var res = await client.PostAsync(robotUrl, content);
        }

        [HttpPost]
        public async Task ManualControl(ManualControlRequestMessage requestMessage)
        {
            var robotUrl = "http://localhost:80/api/ManualControl";
            var client = new HttpClient();
            var content = new StringContent(JsonSerializer.Serialize<ManualControlRequestMessage>(requestMessage), System.Text.Encoding.UTF8, "application/json");
            var res = await client.PostAsync(robotUrl, content);
        }

        [HttpPost]
        public async Task ControlPanel(ControlPanelRequestMessage requestMessage)
        {
            var robotUrl = "http://localhost:80/api/ControlPanel";
            var client = new HttpClient();
            var content = new StringContent(JsonSerializer.Serialize(requestMessage), System.Text.Encoding.UTF8, "application/json");
            var res = await client.PostAsync(robotUrl, content);
        }
        

        [HttpGet]
        public async Task SetManualLift()
        {
            var robotUrl = "http://localhost:80/api/SetManualLift";
            var client = new HttpClient();
            var res = await client.GetAsync(robotUrl);
        }

        [HttpGet]
        public async Task CancelManualLift()
        {
            var robotUrl = "http://localhost:80/api/CancelManualLift";
            var client = new HttpClient();
            var res = await client.GetAsync(robotUrl);
        }

        //[HttpPost]
        //public async Task ManualControlV2(NewRequestMessage requestMessage)
        //{
        //    var robotUrl = "http://localhost:80/api/ManuelControlV2";
        //    var client = new HttpClient();
        //    var content = new StringContent(JsonSerializer.Serialize<NewRequestMessage>(requestMessage), System.Text.Encoding.UTF8, "application/json");
        //    var res = await client.PostAsync(robotUrl, content);
        //}

    }
}
