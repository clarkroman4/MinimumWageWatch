using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.ViewModels
{
    public class AddStateWageViewModel
    {
        [Required(ErrorMessage = "Please enter the minimum wage")]
        [DataType(DataType.Currency)]
        public decimal MinWage { get; set; }

        
        [Required (ErrorMessage="Please Select a State")]
        [StringLengthAttribute(50, MinimumLength = 3, ErrorMessage = "Please enter the full state name")]
        public string State { get; set; }

        [Required (ErrorMessage = "Please enter a valid date")]
        [DataType(DataType.Date)]
        public DateTime EffectiveDate { get; set; }

        public AddStateWageViewModel() { }

    }
}
