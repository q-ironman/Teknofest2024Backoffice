namespace SanayiGUIWebApi.Messages
{
    internal class UiDataRequestMessage<T> where T : class
    {
        public string ClassType { get; set; }
        public T Data { get; set; }
    }
}
