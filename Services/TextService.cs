using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TestProject.Data;
using TestProject.Dtos;
using TestProject.Models;

namespace TestProject.Services
{
    public class TextService: ITextService
    {
        private readonly ApplicationDbContext _context;
       
        public TextService(ApplicationDbContext context)
        {
            _context=context;
          
        }
        public async Task<bool>  CreateTextAsync(Text model)
        {
            if (model == null)
                throw new NullReferenceException("Not  valid  data");
            else{
       await  _context.Texts.AddAsync(model);
           await  _context.SaveChangesAsync();
           return true;
            }
          

        }

        public async Task<IEnumerable<Text>> GetAllTextsAsync()
        {
            var  texts=await _context.Texts.Include(p=>p.Author).ToListAsync();
              return texts;
        }

        public async Task<Text> GetTextByIdAsync(int id)
        {
           return await  _context.Texts.Include(p=>p.Author).FirstOrDefaultAsync(s=>s.Id==id);
        }

         public async Task<Text>  UpdateTextAsync(int id, Text model)
        {
           var  textItem=await   _context.Texts.Include(p=>p.Author).FirstOrDefaultAsync(s=>s.Id==id);
             textItem.Name=model.Name;
             textItem.TextField=model.TextField;
             textItem.DateOfCreation=model.DateOfCreation;
             textItem.Cost=model.Cost;
             textItem.NumberOfSales=model.NumberOfSales;
             _context.SaveChanges();

             return  textItem;

        }

        
    }
}