﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Wage
    {
        public int ID { get; set; }
        public DateTime EffectiveDate { get; set; }
        public decimal MinWage { get; set; }
    }
}
