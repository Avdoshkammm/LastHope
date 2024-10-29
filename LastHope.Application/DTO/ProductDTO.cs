using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LastHope.Application.DTO
{
    public class ProductDTO
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Description { get; set; }
        
        [Required]
        [Range(0, int.MaxValue)]
        public int Cost { get; set; }
    }
}
