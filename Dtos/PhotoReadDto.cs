using System.ComponentModel.DataAnnotations;

namespace TestProject.Dtos
{
    public class PhotoReadDto
    {
        [Key]
        public int Id {get;set;}
         public  string Name{get;set;}

         public string Link {get;set;}

         public  string Size {get;set;}

         public  DateTime DateOfCreation {get;set;}

         public  string NameOfAuthor {get;set;}

         public string NicknameOfAuthor {get;set;}

         public double Cost {get;set;}

         public int NumberOfSales {get;set;}

         



    }
}