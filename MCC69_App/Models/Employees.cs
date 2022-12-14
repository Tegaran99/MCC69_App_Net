using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MCC69_App.Models
{
    public class Employees
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public DateTime HireDate { get; set; }        
        public int Salary { get; set; }        
        

        public Jobs Jobs { get; set; }
        [ForeignKey("Jobs")]
        public int Job_Id { get; set; }

        public Employees Manager { get; set; }
        [ForeignKey("Manager")]
        public int? Manager_Id { get; set; }

        public Departments Departments { get; set; }
        [ForeignKey("Departments")]
        public int Department_Id { get; set; }

    }
}
