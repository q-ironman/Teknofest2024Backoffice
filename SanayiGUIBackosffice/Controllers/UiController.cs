using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SanayiGUIBackosffice.Messages;
using SanayiGUIBackosffice.Model;
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
    }
}
