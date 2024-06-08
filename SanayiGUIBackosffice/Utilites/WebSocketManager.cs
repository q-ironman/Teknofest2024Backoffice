using System;
using System.Net.WebSockets;
using System.Text;

namespace SanayiGUIWebApi.Utilites
{
    public class WebSocketManager : IWebSocketManager
    {
        public List<WebSocket> WebSockets { get; set; }

        public WebSocketManager()
        {
            WebSockets = new List<WebSocket>();
        }

        public async Task AddWebSocketAsync(HttpContext context)
        {
            var webSocket = await context.WebSockets.AcceptWebSocketAsync();
            this.WebSockets.Add(webSocket);
            await HandleWebSocketAsync(context, webSocket);
        }

        private async Task HandleWebSocketAsync(HttpContext context, WebSocket webSocket)
        {
            var buffer = new byte[1024 * 4];
            WebSocketReceiveResult result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

            while (!result.CloseStatus.HasValue)
            {
                var message = System.Text.Encoding.UTF8.GetString(buffer, 0, result.Count);
                System.Console.WriteLine($"Received: {message}");

                await webSocket.SendAsync(new ArraySegment<byte>(System.Text.Encoding.UTF8.GetBytes("Echo: " + message)), result.MessageType, result.EndOfMessage, CancellationToken.None);

                result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            }

            await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
        }
        public async Task BroadcastMessageAsync(string message)
        {
            foreach (var socket in this.WebSockets)
            {
                if (socket.State == WebSocketState.Open)
                {
                    await socket.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes(message)), WebSocketMessageType.Text, true, CancellationToken.None);
                }
            }
        }
    }
}
