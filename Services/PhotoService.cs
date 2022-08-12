using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TestProject.Data;
using TestProject.Dtos;
using TestProject.Models;

namespace TestProject.Services
{
    public class PhotoService: IPhotoService
    {
        private readonly ApplicationDbContext _context;
       
        public PhotoService(ApplicationDbContext context)
        {
            _context=context;
          
        }
        public async Task<bool>  CreatePhotoAsync(Photo model)
        {
            if (model == null)
                throw new NullReferenceException("Not  valid  data");
            else{
       await  _context.Photoes.AddAsync(model);
           await  _context.SaveChangesAsync();
           return true;
            }
          

        }

        public async Task<IEnumerable<Photo>> GetAllPhotoesAsync()
        {
            var  photoes=await _context.Photoes.Include(p=>p.Author).ToListAsync();
              return photoes;
        }

        public async Task<Photo> GetPhotoByIdAsync(int id)
        {
           return await  _context.Photoes.Include(p=>p.Author).FirstOrDefaultAsync(s=>s.Id==id);
        }

        public async Task<Photo>  UpdatePhotoAsync(int id, Photo model)
        {
           var  photoItem=await   _context.Photoes.Include(p=>p.Author).FirstOrDefaultAsync(s=>s.Id==id);
             photoItem.Name=model.Name;
             photoItem.Link=model.Link;
             photoItem.Size=model.Size;
             photoItem.DateOfCreation=model.DateOfCreation;
             photoItem.Cost=model.Cost;
             photoItem.NumberOfSales=model.NumberOfSales;
             _context.SaveChanges();

             return  photoItem;

        }

        
    }
}