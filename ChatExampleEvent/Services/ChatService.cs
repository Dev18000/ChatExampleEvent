namespace ChatExampleEvent.Services
{
    public class ChatService
    {
        public event Action<string, string>? OnMessageReceived;

        public void SendMessage(string user, string message)
        {
            OnMessageReceived?.Invoke(user, message);
        }
    }
}
