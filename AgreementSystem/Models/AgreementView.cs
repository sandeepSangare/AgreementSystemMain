using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgreementSystem.Models
{
    public class AgreementView
    {

        public int Id { get; set; }
        public int Product_Group_Id { get; set; }
        public string Group_Description { get; set; }
        public string Product_Description { get; set; }
        public  int Product_Id { get; set; }
        public DateTime Effective_Date { get; set; }
        public DateTime Expiration_Date { get; set; }
        public decimal Product_Price { get; set; }
        public decimal New_Price { get; set; }
        public bool Active { get; set; }
    }
}
