namespace ChatExampleEvent.Services
{
    public class ChatService
    {
        //private readonly object _lock = new();

        //private event Action<string, string>? _onMessageReceived;

        //public event Action<string, string> OnMessageReceived
        //{
        //    add
        //    {
        //        lock (_lock)
        //        {
        //            _onMessageReceived += value;
        //        }
        //    }
        //    remove
        //    {
        //        lock (_lock)
        //        {
        //            _onMessageReceived -= value;
        //        }
        //    }
        //}

        //public void SendMessage(string user, string message)
        //{
        //    _onMessageReceived?.Invoke(user, message);
        //}
        public event Action<string, string>? OnMessageReceived;

        public void SendMessage(string user, string message)
        {
            OnMessageReceived?.Invoke(user, message);
        }
    }
}
