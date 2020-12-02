using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

/* POST TEMPLATE
{
    "parcelNumber": "AA666666AA",
    "recipientName": "Rene Kristofer Pohlak",
    "destinationCountry": "EE",
    "weight": 5.124,
    "price": 1.42,
    "bagParcelsId": "1a71162a-4b17-4308-7314-08d89670be82"
}
*/

namespace REST_API.Models
{
    public class Parcel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
