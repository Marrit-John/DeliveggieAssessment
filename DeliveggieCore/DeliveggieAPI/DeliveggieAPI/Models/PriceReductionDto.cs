using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveggieAPI.Models
{
    public class PriceReductionDto
    {
        public int DayOfWeek { get; set; }  // Day of the week (e.g., 0 for Sunday, 6 for Saturday)
        public decimal Reduction { get; set; } // Price reduction as a percentage (e.g., 0.2 for 20%)
    }
}
