using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Project.Data.Entities
{
    public class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        [Required, MaxLength(150)]
        public string ProductName { get; set; }

        [Required, DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required]
        public short Stock { get; set; }
    }
}
