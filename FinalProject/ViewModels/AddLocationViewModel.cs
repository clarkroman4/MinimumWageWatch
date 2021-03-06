﻿using FinalProject.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.ViewModels
{
    public class AddLocationViewModel : StatesListViewModel
    {

        [Required(ErrorMessage="You must enter a name for the location")]
        [Display(Name="Location Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the Street Address")]
        [Display(Name = "Street Address")]
        public string Address { get; set; }

        [Required (ErrorMessage = "Please enter the City")]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required (ErrorMessage = "Please enter the State")]
        [Display(Name = "State")]
        public string State { get; set; }

        [Required]
        public int ZIP { get; set; }
    }
}
