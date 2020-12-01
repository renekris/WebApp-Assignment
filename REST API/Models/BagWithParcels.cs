using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace REST_API.Models
{
    public class BagWithParcels
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(15)]
        [RegularExpression(@"[A-Za-z0-9]+", ErrorMessage = "Only alphanumeric characters")]
        public string BagNumber { get; set; }

        public ICollection<Parcels> ListOfParcels { get; set; }

    }

    public class Parcels
    {
        public int Id { get; set; }
        public string ListOfParcels { get; set; }
    }
}
