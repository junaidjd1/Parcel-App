using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProAdvantages.Models
{
    public class Parcel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]//this is for to chect db for pk
        public int PID {get;set;}
        public string Destination{get;set;}
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DeliveryDate { get; set; }
        public string InsuranceWorth { get; set; }
        public string Dimension { get; set; }
        public string Weight { get; set; }

        public int FID { get; set; }
        public Franchise Franchise { get; set; }
        public ICollection<DeliveryService> DeliveryServices { get; set; }
         
    }
}
