using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GPACStore.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(20)]
        public string productName { get; set; }

        [Required]
        public decimal ProductPrice { get; set; }

        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime ArrivalDate { get; set; }
    }
}
