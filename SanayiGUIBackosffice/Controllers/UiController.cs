﻿using MapManager;
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
        private readonly RouteManager routeManager;
        public UiController(RouteManager routeManager)
        {
            this.routeManager = routeManager;
        }
        [HttpPost]
        public List<string> StartCommand(StartCommandRequestMessage requestMessage)
        {
            List<string> shortestPath = new();
            var commandList = requestMessage.Command;
            for (int i = 0; i < commandList.Count-1; i++)
            {
                var startLabel = commandList[i].Value;
                var endLabel = commandList[i + 1].Value;
                var pathPart = routeManager.GetShortestPath(startLabel, endLabel);
                shortestPath.AddRange(pathPart);
            }
            return shortestPath;
            //var res = shortestPath.ToHashSet().ToList();
            //return res;
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
