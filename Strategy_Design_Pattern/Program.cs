using StratergyDesignPattern;
using StratergyDesignPattern.Good;

internal class Program
{
    private static void Main(string[] args)
    {
        Policy policy = new Policy { type = "Auto" };

        // Select a strategy dynamically
        PolicyContext policyContext = new PolicyContext(new AutoInsurance());
        Console.WriteLine($"Auto Insurance Premium: {policyContext.GetPremium(policy)}");

        // Change the strategy at runtime
        policyContext.SetStrategy(new HealthInsurance());
        Console.WriteLine($"Health Insurance Premium: {policyContext.GetPremium(policy)}");

        // Another strategy
        policyContext.SetStrategy(new PersonalPropertyInsurance());
        Console.WriteLine($"Personal Property Insurance Premium: {policyContext.GetPremium(policy)}");
    }
}

namespace StratergyDesignPattern
{
    public class Policy
    {
        public string type { get; set; }
    }

    namespace Bad
    {
        public class PolicyService
        {
            public double CalculatePremium(Policy policy)
            {
                if (policy.type == "Auto")
                {
                    return 100;
                }
                else if (policy.type == "PersonalProperty")
                {
                    return 200;
                }
                else if (policy.type == "Health")
                {
                    return 300;
                }
                return 0;
            }
        }
    }

    namespace Good
    {
        // Strategy Interface
        public interface IPolicyService
        {
            double CalculatePremium(Policy policy);
        }

        // Concrete Strategies
        public class AutoInsurance : IPolicyService
        {
            public double CalculatePremium(Policy policy)
            {
                return 100;
            }
        }

        public class PersonalPropertyInsurance : IPolicyService
        {
            public double CalculatePremium(Policy policy)
            {
                return 200;
            }
        }

        public class HealthInsurance : IPolicyService
        {
            public double CalculatePremium(Policy policy)
            {
                return 300;
            }
        }

        // Context class (previously named PolicyService)
        public class PolicyContext
        {
            private IPolicyService _policyService;

            public PolicyContext(IPolicyService policyService)
            {
                this._policyService = policyService;
            }

            public void SetStrategy(IPolicyService policyService)
            {
                this._policyService = policyService;
            }

            public double GetPremium(Policy policy)
            {
                return _policyService.CalculatePremium(policy);
            }
        }
    }
}