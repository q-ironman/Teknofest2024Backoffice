using SanayiGUIWebApi.Utilites;

namespace SanayiGUIWebApi.Middlewares
{
    public class WebSocketMiddleware
    {
        IWebSocketManager _manager;
        RequestDelegate next;

        public WebSocketMiddleware(RequestDelegate next, IWebSocketManager webSocketManager)
        {
            this._manager = webSocketManager;
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.WebSockets.IsWebSocketRequest)
            {

                await this._manager.AddWebSocketAsync(context);
                return;
            }
            else
            {
                await this.next.Invoke(context);
            }
        }
    }
}
