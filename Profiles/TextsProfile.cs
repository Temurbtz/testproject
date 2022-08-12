using AutoMapper;
using TestProject.Dtos;
using TestProject.Models;

namespace TestProject.Profiles
{
    public class TextsProfile:Profile
    {
        public TextsProfile()
        {
           CreateMap<Text,TextReadDto>()
           .ForMember(s=> s.NameOfAuthor,m=>m.MapFrom(m=>m.Author.FirstName))
           .ForMember(s => s.NicknameOfAuthor, m=>m.MapFrom(m=>m.Author.Nickname));

           CreateMap<TextCreateDto,Text>();
          
        }
    }
}