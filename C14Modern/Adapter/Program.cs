namespace Adapter
{
    public class Program
    {
        static void Main(string[] args)
        {
            var legacySmsSender = new LegacySmsSender();
            INotifier notifier = new SmsAdapter(legacySmsSender);
            notifier.Send("Work on math", "Don't forget to complete your math homework!");
        }

        public interface INotifier {
            void Send(string title, string message);
        }

        public class LegacySmsSender
        {
            public void SendSms(string jsonPayload)
            {
                Console.WriteLine($"Sending SMS with payload: {jsonPayload}");
            }
        }

        public class SmsAdapter: INotifier { 
            private readonly LegacySmsSender _legacySmsSender;

            public SmsAdapter(LegacySmsSender legacySmsSender)
            {
                _legacySmsSender = legacySmsSender;
            }

            public void Send(string title, string message)
            {
                var json = new { Title = title, Message = message };
                var jsonString = System.Text.Json.JsonSerializer.Serialize(json);
                _legacySmsSender.SendSms(jsonString);
            }
        }
    }
}
