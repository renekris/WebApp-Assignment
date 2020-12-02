using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

/* POST TEMPLATE
{
    "shipmentId": "9c47a337-d09c-4c06-a164-08d896700e9b"
}
*/

namespace REST_API.Models
{
    public class ShipmentBags
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; } = default!;


        public ICollection<BagParcels>? ListBagPar { get; set; }
        public ICollection<BagLetters>? ListBagLet { get; set; }

        [ForeignKey(nameof(Shipment))]
        public Guid ShipmentId { get; set; } = default!;
        public Shipment? Shipment { get; set; }
    }
}
