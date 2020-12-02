using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace REST_API.Models
{
    public class ShipmentBags
    {
        public Guid Id { get; set; } = default!;


        public ICollection<BagParcels>? ListBagPar { get; set; }
        public ICollection<BagLetters>? ListBagLet { get; set; }

        [ForeignKey(nameof(Shipment))]
        public Guid ShipmentId { get; set; } = default!;
        public Shipment? Shipment { get; set; }
    }
}
