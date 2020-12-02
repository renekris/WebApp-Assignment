using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace REST_API.Models
{
    public class BagLetters
    {
        public Guid Id { get; set; } = default!;

        [StringLength(15, ErrorMessage = "String must be 15 in length")]
        [RegularExpression(@"[A-Za-z0-9]+")]
        public string BagNumber { get; set; } = default!;

        [Range(1, double.PositiveInfinity)]
        public int LetterCount { get; set; } = default!;

        [Column(TypeName = "decimal(18,3)")]
        public double Weight { get; set; } = default!;

        [Column(TypeName = "decimal(18,2)")]
        public double Price { get; set; } = default!;

        [ForeignKey(nameof(ShipmentBags))]
        public Guid ShipmentBagsId { get; set; } = default!;
        public ShipmentBags? ShipmentBags { get; set; }
    }
}
