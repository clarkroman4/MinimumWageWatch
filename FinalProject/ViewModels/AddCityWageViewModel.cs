﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.ViewModels
{
    public class AddCityWageViewModel
    {
        [Required(ErrorMessage = "Please Enter the City Name")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please Enter the full State name")]
        public string State{ get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public double MinWage { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EffectiveDate { get; set; }

        public AddCityWageViewModel() { }


    }
}