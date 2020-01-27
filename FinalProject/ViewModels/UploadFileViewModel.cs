using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.ViewModels
{
    public class UploadFileViewModel
    {
        [Required(ErrorMessage="Please select a file to upload")]
        public IFormFile file { get; set; }
    }
}
