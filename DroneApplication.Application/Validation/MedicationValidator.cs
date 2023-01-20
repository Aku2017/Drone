using DroneApplication.Application.Utility;
using DroneApplication.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneApplication.Application.Validation
{
    public class MedicationValidator: AbstractValidator<Medication>
    {
        public string Name { get; set; }

        public string Code { get; set; }
        public MedicationValidator()
        {
            this.BuildRules();
        }

        public void BuildRules()
        {
            RuleFor(Medication => Medication.MedicationName).NotNull().Matches(RegexUtil.lettersnumbersunderscorehyphen);
            RuleFor(Medication => Medication.Code).NotNull().Matches(RegexUtil.Uppercaseunderscorenumbers)
                .WithMessage(String.Format("Code must contain UPPER CASE LETTERS, and numbers"));
        }
    }
}
