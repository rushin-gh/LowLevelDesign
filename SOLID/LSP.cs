using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSP
{
    namespace Bad
    {
        public class Policy
        {
            public virtual void MedicalExamination()
            {
                Console.WriteLine("Medical examination required.");
            }
        }

        public class AutoInsurancePolicy : Policy
        {
            public override void MedicalExamination()
            {
                throw new NotImplementedException("Auto insurance does not require medical examination!");
            }
        }

    }

    namespace Good
    {
        public abstract class Policy
        {
            public abstract void CalculatePremium();
        }

        public interface IMedicalExaminationRequired
        {
            void MedicalExamination();
        }

        public class LifeInsurancePolicy : Policy, IMedicalExaminationRequired
        {
            public override void CalculatePremium() { /* Premium logic */ }
            public void MedicalExamination() { /* Examination logic */ }
        }

        public class AutoInsurancePolicy : Policy
        {
            public override void CalculatePremium() { /* Premium logic */ }
        }
    }
}
