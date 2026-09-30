namespace Bridge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var emailSender = new EmailSender();
            var smsSender = new SMSSender();
            var alertNotification = new AlertNotification(emailSender);
            var reportingNotification = new ReportingNotification(smsSender);
            alertNotification.Send("This is an alert message.");
            reportingNotification.Send("This is a report message.");
        }

        public interface IMessageSender
        {
            void SendMessage(string message);
        }

        public class EmailSender : IMessageSender
        {
            public void SendMessage(string message)
            {
                Console.WriteLine("Sending email: " + message);
            }
        }

        public class SMSSender : IMessageSender
        {
            public void SendMessage(string message)
            {
                Console.WriteLine("Sending SMS: " + message);
            }
        }

        public abstract class Message
        {
            protected IMessageSender _messageSender;
            protected Message(IMessageSender messageSender)
            {
                _messageSender = messageSender;
            }
            public abstract void Send(string message);
        }

        public class AlertNotification : Message
        {
            public AlertNotification(IMessageSender messageSender) : base(messageSender)
            {
            }

            public override void Send(string message)
            {
                message = "Alert: " + message;
                _messageSender.SendMessage(message);
            }
        }

        public class ReportingNotification : Message
        {
            public ReportingNotification(IMessageSender messageSender) : base(messageSender)
            {
            }

            public override void Send(string message)
            {
                message = "Report: " + message;
                _messageSender.SendMessage(message);
            }
        }
    }
}
