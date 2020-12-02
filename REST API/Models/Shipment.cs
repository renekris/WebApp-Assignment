using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace REST_API.Models
{
    public class Shipment
    {

        public Guid Id { get; set; } = default!;

        [RegularExpression(@"[A-Za-z0-9]{3}-[A-Za-z0-9]{6}")]
        public string ShipmentNumber { get; set; } = default!;

        public enum AirportType { TLL, RIX, HEL }
        public AirportType? Airport { get; set; } = default!;

        [StringLength(6)]
        [RegularExpression(@"[A-Za-z]{2}[0-9]{4}")]
        public string FlightNumber { get; set; } = default!;

        [DataType(DataType.DateTime)]
        public DateTime FlightDate { get; set; } = default!;


        public ICollection<ShipmentBags>? ListBags { get; set; }
    }
}
