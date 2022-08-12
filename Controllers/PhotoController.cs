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
    public  class  PhotoController:ControllerBase
    {
        private readonly IPhotoService _service;
        private readonly UserManager<Author> _userManager;
        private readonly IMapper _mapper;

        public PhotoController(IPhotoService  service, UserManager<Author> userManager, IMapper mapper)
        {
            _service=service;
            _userManager=userManager;
            _mapper=mapper;
        }
        // private readonly MockCommanderRepo   _repository=new MockCommanderRepo();

        [HttpGet]
        public async Task<ActionResult <IEnumerable<PhotoReadDto>>> GetAllPhotoes()
        {
            var photoItems=await _service.GetAllPhotoesAsync();
            return Ok(_mapper.Map<IEnumerable<PhotoReadDto>>(photoItems));
        }

        [HttpPost]
        public async Task<ActionResult<PhotoReadDto>> CreatePhoto(PhotoCreateDto photoCreateDto)
        {
            var photoModel = _mapper.Map<Photo>(photoCreateDto);
            photoModel.Author=  await _userManager.GetUserAsync(User);
            var  result=await  _service.CreatePhotoAsync(photoModel);
            if(!result){
              return BadRequest("Not valid  data;");
            }
            var photoReadDto = _mapper.Map<PhotoReadDto>(photoModel);
            return CreatedAtRoute(nameof(GetPhotoById), new {Id =photoReadDto.Id}, photoReadDto);   
        }

        [HttpGet("{id}", Name="GetPhotoById")]
        public async  Task<ActionResult <PhotoReadDto>> GetPhotoById(int id)
        {
           var photoItem= await _service.GetPhotoByIdAsync(id);
           if(photoItem!=null){
              return Ok(_mapper.Map<PhotoReadDto>(photoItem));
           }
           return NotFound();
           
        }

        [HttpPut("{id}")]
        public async Task<ActionResult <PhotoReadDto>> UpdateText(int id, PhotoCreateDto dto)
        {
               var photoModel = _mapper.Map<Photo>(dto);
                var checkItem=await _service.GetPhotoByIdAsync(id);
               if (photoModel==null | checkItem==null)
               {
                   return BadRequest("Invalid");
               }
               
               var  user=await _userManager.GetUserAsync(User);
               if(checkItem.Author!=user){
                return BadRequest("Invalid");
               }
                var result=await _service.UpdatePhotoAsync(id,photoModel);  
                 if(result!=null){
                    return Ok(_mapper.Map<PhotoReadDto>(result));
                }
                else{
                    return BadRequest("Invalid");
                }
              
              
             
                 
        }
    }
}