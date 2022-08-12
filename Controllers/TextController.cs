using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TestProject.Dtos;
using TestProject.Models;
using TestProject.Services;

namespace TestProject.Controllers
{   
   
    [Route("api/[controller]")]
    [ApiController]
     [Authorize]
    public  class  TextController:ControllerBase
    {
        private readonly ITextService _service;
        private readonly UserManager<Author> _userManager;
        private readonly IMapper _mapper;

        public TextController(ITextService  service, UserManager<Author> userManager, IMapper mapper)
        {
            _service=service;
            _userManager=userManager;
            _mapper=mapper;
        }
        // private readonly MockCommanderRepo   _repository=new MockCommanderRepo();

        [HttpGet]
        public async Task<ActionResult <IEnumerable<TextReadDto>>> GetAllTexts()
        {
            var textItems=await _service.GetAllTextsAsync();
            return Ok(_mapper.Map<IEnumerable<TextReadDto>>(textItems));
        }

        [HttpPost]
        public async Task<ActionResult<TextReadDto>> CreateText(TextCreateDto textCreateDto)
        {
            var textModel = _mapper.Map<Text>(textCreateDto);
            textModel.Author=  await _userManager.GetUserAsync(User);
            var  result=await  _service.CreateTextAsync(textModel);
            if(!result){
              return BadRequest("Not valid  data;");
            }
            var textReadDto = _mapper.Map<TextReadDto>(textModel);
            return CreatedAtRoute(nameof(GetTextById), new {Id =textReadDto.Id}, textReadDto);   
        }

        [HttpGet("{id}", Name="GetTextById")]
        public async  Task<ActionResult <TextReadDto>> GetTextById(int id)
        {
           var textItem= await _service.GetTextByIdAsync(id);
           if(textItem!=null){
              return Ok(_mapper.Map<TextReadDto>(textItem));
           }
           return NotFound();
           
        }


         [HttpPut("{id}")]
        public async Task<ActionResult <TextReadDto>> UpdateText(int id, TextCreateDto dto)
        {
               var textModel = _mapper.Map<Text>(dto);
                var checkItem=await _service.GetTextByIdAsync(id);
               if (textModel==null | checkItem==null)
               {
                   return BadRequest("Invalid");
               }
               
               var  user=await _userManager.GetUserAsync(User);
               if(checkItem.Author!=user){
                return BadRequest("Invalid");
               }
                var result=await _service.UpdateTextAsync(id,textModel);  
                 if(result!=null){
                    return Ok(_mapper.Map<TextReadDto>(result));
                }
                else{
                    return BadRequest("Invalid");
                }
              
              
             
                 
        }
        
    }
}