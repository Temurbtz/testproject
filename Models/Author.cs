using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace TestProject.Models
{
    public class Author:IdentityUser
    {
       
        [Required]
        [MaxLength(255)]
        public string FirstName {get;set;}
        [Required]
        [MaxLength(255)]
        public  string LastName {get;set;}
        
       
        
        [Required]
        [MaxLength(255)]
       
        public string Nickname {get;set;}

        [DataType(DataType.Date)]
       
        public DateTime DateOfBirth { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfRegistration { get; set; }

         public ICollection<Photo> Photoes { get; set; }

          public ICollection<Text> Texts { get; set; }
    }
}