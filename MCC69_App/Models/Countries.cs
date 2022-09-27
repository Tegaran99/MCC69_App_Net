using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MCC69_App.Models
{
    public class Countries
    {
        [Key]
        public int Id { get; set; }
        
        public string CountryName { get; set; }

        public Regions Regions { get; set; }
        [ForeignKey("Regions")]
        public int Region_Id { get; set; }
    }
}
