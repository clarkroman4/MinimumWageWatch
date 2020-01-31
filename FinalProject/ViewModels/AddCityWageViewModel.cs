using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.ViewModels
{
    public class AddCityWageViewModel : StatesListViewModel
    {
        [Required(ErrorMessage = "Please Enter the City Name")]
        public string City  { get; set; }

        [Required(ErrorMessage = "Please Enter the full State name")]
        [StringLengthAttribute(50, MinimumLength = 3, ErrorMessage = "Please enter the full state name")]
        public string State { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal MinWage { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EffectiveDate { get; set; }

        public AddCityWageViewModel() { }


    }
}
