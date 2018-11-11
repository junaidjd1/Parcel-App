using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProAdvantages.Models
{
    public class Franchise
    {
       [Key]
        public int ID { get; set; }
        public string Type { get; set; }
        public string Address { get; set; }

        public ICollection<Parcel> Parcels { get; set; }
    }
}

