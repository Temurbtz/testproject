using System.ComponentModel.DataAnnotations;

namespace TestProject.Dtos
{
    public  class  PhotoCreateDto
    {
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

       

       public double  Cost {get;set;}

       public int NumberOfSales {get;set;} 
    }
}