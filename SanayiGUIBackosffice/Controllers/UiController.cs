using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SanayiGUIBackosffice.Messages;
using SanayiGUIBackosffice.Model;
using SanayiGUIWebApi.Messages;
using System.Text.Json;

namespace SanayiGUIWebApi.Controllers
{
    [Route("api/[action]")]
    [ApiController]
    public class UiController : ControllerBase
    {
        [HttpPost]
        public List<Movement> StartCommand(StartCommandRequestMessage requestMessage)
        {

            return new List<Movement> { };
        }

        [HttpGet]
        public void MakeEmergencyBrake()
        {

        }

        [HttpGet]
        public async Task EmptyTour()
        {
            var robotUrl = "http://localhost:80/api/EmptyTour";
            var client = new HttpClient();
            var res = await client.GetAsync(robotUrl);
        }

        [HttpPost]
        public async Task ManualControl(ManualControlRequestMessage requestMessage)
        {
            var robotUrl = "http://localhost:80/api/ManualControl";
            var client = new HttpClient();
            var content = new StringContent(JsonSerializer.Serialize<ManualControlRequestMessage>(requestMessage), System.Text.Encoding.UTF8, "application/json");
            var res = await client.PostAsync(robotUrl, content);
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
