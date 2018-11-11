using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProAdvantages.Models
{
    public class DeliveryService
    {
        [Key]
        public int DSID { get; set; }
        public String Type { get; set; }
        public string DeliveryRoute { get; set; }

        public int PID { get; set; }
        public Parcel Parcel { get; set; }

    }
}
