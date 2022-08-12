using AutoMapper;
using TestProject.Dtos;
using TestProject.Models;

namespace TestProject.Profiles
{
    public class PhotoesProfile:Profile
    {
        public PhotoesProfile()
        {
           CreateMap<Photo,PhotoReadDto>()
           .ForMember(s=> s.NameOfAuthor,m=>m.MapFrom(m=>m.Author.FirstName))
           .ForMember(s => s.NicknameOfAuthor, m=>m.MapFrom(m=>m.Author.Nickname));

           CreateMap<PhotoCreateDto, Photo>();
          
        }
    }
}