
namespace SanayiGUIWebApi.Utilites
{
    public interface IWebSocketManager
    {
        Task AddWebSocketAsync(HttpContext context);
        Task BroadcastMessageAsync(string message);
    }
}