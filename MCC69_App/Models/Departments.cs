using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MCC69_App.Models
{
    public class Departments
    {
        [Key]
        public int Id { get; set; }
        public string DepartmentName { get; set; }
                
        public Locations Locations { get; set; }
        [ForeignKey("Locations")]
        public int Location_Id { get; set; }

    }
}
