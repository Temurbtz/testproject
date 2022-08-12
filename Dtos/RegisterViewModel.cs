using System.ComponentModel.DataAnnotations;

namespace TestProject.Dtos
{
    public class RegisterViewModel
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

        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Password { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string ConfirmPassword { get; set; }
    }
}