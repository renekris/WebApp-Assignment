using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

/* POST TEMPLATE
{
    "bagNumber": "123451234512345",
    "shipmentBagsId": "0a71162a-4b17-4308-7314-08d89670be82"
}
*/

namespace REST_API.Models
{
    public class BagParcels
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; } = default!;

        [StringLength(15)]
        [RegularExpression(@"[A-Za-z0-9]+")]
        public string BagNumber { get; set; } = default!;


        public ICollection<Parcel>? ListParcels { get; set; }

        [ForeignKey(nameof(ShipmentBags))]
        public Guid ShipmentBagsId { get; set; } = default!;
        public ShipmentBags? ShipmentBags { get; set; }
    }
}
