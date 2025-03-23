// Software should be open for extension but closed for modification

namespace OCD
{
    namespace Bad
    {
        public class PolicyService
        {
            public double CalculatePremium(string policyType)
            {
                if (policyType == "Life") return 5000;
                else if (policyType == "Auto") return 2000;
                else return 1000; // New policyType? Modify this method 😖
            }
        }
    }

    namespace Good
    {
        public abstract class Policy
        {
            public abstract double CalculatePremium();
        }

        public class LifeInsurancePolicy : Policy
        {
            public override double CalculatePremium() => 5000;
        }

        public class AutoInsurancePolicy : Policy
        {
            public override double CalculatePremium() => 2000;
        }
    }
}
