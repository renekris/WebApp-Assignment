using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace REST_API.Models
{
    public class BagParcels
    {
        public Guid Id { get; set; } = default!;

        [StringLength(15, ErrorMessage = "String must be 15 in length")]
        [RegularExpression(@"[A-Za-z0-9]+")]
        public string BagNumber { get; set; } = default!;


        public ICollection<Parcel>? ListParcels { get; set; }

        [ForeignKey(nameof(ShipmentBags))]
        public Guid ShipmentBagsId { get; set; } = default!;
        public ShipmentBags? ShipmentBags { get; set; }
    }
}
