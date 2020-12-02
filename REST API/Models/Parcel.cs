using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace REST_API.Models
{
    public class Parcel
    {
        public Guid Id { get; set; } = default!;

        [RegularExpression(@"[A-Za-z]{2}[0-9]{6}[A-Za-z]{2}")]
        public string ParcelNumber { get; set; } = default!;

        [StringLength(100)]
        public string RecipientName { get; set; } = default!;

        [RegularExpression(@"[A-Z]{2}")]
        public string DestinationCountry { get; set; } = default!;

        [Column(TypeName = "decimal(18,3)")]
        public decimal Weight { get; set; } = default!;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; } = default!;


        [ForeignKey(nameof(BagParcels))]
        public Guid BagParcelsId { get; set; } = default!;
        public BagParcels? BagParcels { get; set; }
    }
}
