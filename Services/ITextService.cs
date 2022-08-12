using TestProject.Dtos;
using TestProject.Models;

namespace TestProject.Services
{
    public interface ITextService
    {
          Task<bool>  CreateTextAsync(Text model); 
         
         Task<Text> GetTextByIdAsync(int id);

         Task<IEnumerable<Text>> GetAllTextsAsync();

           Task<Text> UpdateTextAsync(int id, Text model);
    }
}