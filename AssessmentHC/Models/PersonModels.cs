using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AssessmentHC.Models
{
    public class Person
    {

        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Display (Name="First Name")]

        public string FName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LName { get; set; }
        [Required]
        [Range(10,90)]
        [Display(Name = "Age")]
        public int Age { get; set; }


        [DataType(DataType.MultilineText)]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name ="Interests")]
        public string Interests { get; set; }
        
        [Display(Name = "Upload Profile Picture")]
        public string ProfileImgPath { get; set; }
        [Display(Name = "Name")]
        public string FullName
        {
            get
            {
                return  FName+ " " + LName;
            }
        }
    }

    public class PersonContext : DbContext
    {
        public DbSet<Person> persons { get; set; }
    }
}