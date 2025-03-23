using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP
{
    namespace Bad
    {
        public interface IPolicy
        {
            void CalculatePremium();
            void RequireMedicalExamination();
            void ProcessClaim();
        }

        public class AutoInsurancePolicy : IPolicy
        {
            public void CalculatePremium() { /* Premium logic */ }
            public void RequireMedicalExamination() { throw new NotImplementedException(); } // ❌ Not needed
            public void ProcessClaim() { /* Claim logic */ }
        }
    }

    namespace Good
    {
        public interface IPolicy
        {
            void CalculatePremium();
        }

        public interface IMedicalExaminationRequired
        {
            void RequireMedicalExamination();
        }

        public interface IClaimProcessable
        {
            void ProcessClaim();
        }

        // Now, policies only implement what they need
        public class LifeInsurancePolicy : IPolicy, IMedicalExaminationRequired, IClaimProcessable
        {
            public void CalculatePremium() { /* Premium logic */ }
            public void RequireMedicalExamination() { /* Examination logic */ }
            public void ProcessClaim() { /* Claim logic */ }
        }

        public class AutoInsurancePolicy : IPolicy, IClaimProcessable
        {
            public void CalculatePremium() { /* Premium logic */ }
            public void ProcessClaim() { /* Claim logic */ }
        }
    }
}
