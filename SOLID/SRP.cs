// SRP : A class should have only one reason to change

namespace SRP
{
    namespace Bad
    {
        public class PolicyService
        {
            public void CalculatePremium() { /* Calculates premium */ }
            public void SavePolicyToDatabase() { /* Saves policy */ }
            public void SendNotification() { /* Sends notification */ }
        }
    }

    namespace Good
    {
        public class Policy
        {
            public void CalculatePremium() { /* Calculates premium */ }
        }

        public class PolicyRepository
        {
            public void SavePolicyToDatabase() { /* Saves policy */ }
        }

        public class NotificationService
        {
            public void SendNotification() { /* Sends notification */ }
        }
    }
}
