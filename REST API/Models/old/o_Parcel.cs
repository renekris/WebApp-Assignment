using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace REST_API.Models
{
    public class o_Parcel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(10, MinimumLength = 10)]
        [RegularExpression(@"[A-Za-z]{2}[0-9]{6}[A-Za-z]{2}")]
        public string ParcelNumber { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(100)]
        public string RecipientName { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(2, MinimumLength = 2)]
        public string DestinationCountry { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Column(TypeName = "decimal(18,3)")]
        public decimal Weight { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
    }
}