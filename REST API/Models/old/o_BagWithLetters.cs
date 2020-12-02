using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace REST_API.Models
{
    public class o_BagWithLetters
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(15)]
        [RegularExpression(@"[A-Za-z0-9]+", ErrorMessage = "Only alphanumeric characters")]
        public string BagNumber { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Range(1, Double.PositiveInfinity, ErrorMessage = "The field must be greater than 0.")]
        public int CountOfLetters { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Column(TypeName = "decimal(18,3)")]
        public decimal Weight { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

    }
}
