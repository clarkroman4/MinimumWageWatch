using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.ViewModels
{
    public class SearchViewModel
    {
        [Required(ErrorMessage = "Please enter a search term")]
        [Display(Name="Search Term")]
        public string SearchTerm { get; set; }

    }
}
