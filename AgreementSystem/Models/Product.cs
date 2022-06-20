using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AgreementSystem.Models
{
    
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [ForeignKey("ProductGroup")]
        public int Product_Group_Id { get; set; }
        public ProductGroup ProductGroup { get; set; }
        public string Product_Description { get; set; }
        public int Product_Number { get; set; }
        public double Price { get; set; }
        public int Active { get; set; }
    }
}
