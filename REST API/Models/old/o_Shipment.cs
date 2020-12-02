using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace REST_API.Models
{
    public class o_Shipment
    {
        public enum AirportType
        { 
            TLL,
            RIX,
            HEL 
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(10)]
        [RegularExpression(@"[A-Za-z0-9]{3}-[A-Za-z0-9]{6}")]
        public string ShipmentNumber { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public AirportType Airport { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(6)]
        [RegularExpression(@"[A-Za-z]{2}[0-9]{4}")]
        public string FlightNumber { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.DateTime)]
        public DateTime FlightDate { get; set; }

        public ICollection<Bags> ListOfBags { get; set; }

    }

    public class Bags
    {
        public int Id { get; set; }
        public string ListOfBags { get; set; }
    }
}
