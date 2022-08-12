using System.ComponentModel.DataAnnotations;

namespace  TestProject.Models 
{
     public class Photo
    {
      [Key]
       public int Id {get;set;}
       [Required]
       [MaxLength(255)]
       public  string Name  {get;set;}

      [Required]
       public  string Link  {get;set;}

      [Required]
       [MaxLength(255)]
       public string Size  {get;set;}

        [DataType(DataType.Date)]
        public DateTime DateOfCreation { get; set; }

         public Author  Author {get;set;}
          [Required]
       public double  Cost {get;set;}
 [Required]
       public int NumberOfSales {get;set;}
    }
}