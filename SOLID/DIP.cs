// High-level modules should not depend on low-level modules. Both should depend on abstractions

namespace DIP
{
    namespace Bad
    {
        public class EmailNotification
        {
            public void SendEmail(string message)
            {
                Console.WriteLine($"Email Sent: {message}");
            }
        }

        public class PolicyService
        {
            private readonly EmailNotification _emailNotification;

            public PolicyService()
            {
                _emailNotification = new EmailNotification(); // ❌ Tight coupling
            }

            public void ProcessPolicy()
            {
                Console.WriteLine("Processing policy...");
                _emailNotification.SendEmail("Policy has been processed.");
            }
        }
    }

    namespace Good
    {
        public interface INotificationService
        {
            void SendNotification(string message);
        }

        public class EmailNotification : INotificationService
        {
            public void SendNotification(string message)
            {
                Console.WriteLine($"Email Sent: {message}");
            }
        }

        public class SmsNotification : INotificationService
        {
            public void SendNotification(string message)
            {
                Console.WriteLine($"SMS Sent: {message}");
            }
        }

        // PolicyService now depends on the interface, not a concrete class
        public class PolicyService
        {
            private readonly INotificationService _notificationService;

            public PolicyService(INotificationService notificationService)
            {
                _notificationService = notificationService;
            }

            public void ProcessPolicy()
            {
                Console.WriteLine("Processing policy...");
                _notificationService.SendNotification("Policy has been processed.");
            }
        }

        /*
            PolicyService emailService = new PolicyService(new EmailNotification());
            emailService.ProcessPolicy(); // Uses Email

            PolicyService smsService = new PolicyService(new SmsNotification());
            smsService.ProcessPolicy(); // Uses SMS
         */
    }
}
