using System.ComponentModel.DataAnnotations;

namespace TestProject.Models
{
    public class Text
    {
          [Key]
       public int Id {get;set;}
       [Required]
       [MaxLength(255)]
       public  string Name{get;set;}

      [Required]
       public  string TextField {get;set;}

        [DataType(DataType.Date)]
        public DateTime DateOfCreation { get; set; }

         public double  Cost {get;set;}

         public Author  Author {get;set;}

      

       public int NumberOfSales {get;set;}
    }
}