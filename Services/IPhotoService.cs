using TestProject.Dtos;
using TestProject.Models;

namespace TestProject.Services
{
    public interface IPhotoService
    {
          Task<bool>  CreatePhotoAsync(Photo model); 
         
         Task<Photo> GetPhotoByIdAsync(int id);

         Task<IEnumerable<Photo>> GetAllPhotoesAsync();

         Task<Photo> UpdatePhotoAsync(int id, Photo model);
    }
}