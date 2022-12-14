using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using TestProject.Dtos;
using TestProject.Models;

namespace TestProject.Services
{
    public class UserService: IUserService
    {
        private readonly UserManager<Author> _userManager;
        private readonly IConfiguration _configuration;

        public UserService(UserManager<Author> userManager,IConfiguration configuration)
        {
            _userManager=userManager;
              _configuration=configuration;
        }

         public async Task<UserManagerResponse> RegisterUserAsync(RegisterViewModel model)
        {

            if (model == null)
                throw new NullReferenceException("Reigster Model is null");

            if (model.Password != model.ConfirmPassword)
                return new UserManagerResponse
                {
                    Message = "Confirm password doesn't match the password",
                    IsSuccess = false,
                };

            var author = new Author
            {
                FirstName=model.FirstName,
                LastName=model.LastName,
                Nickname=model.Nickname,
                DateOfBirth=model.DateOfBirth,
                DateOfRegistration=DateTime.Today,
                Email = model.Email,
                UserName = model.Email
            };
           
             var result = await _userManager.CreateAsync(author, model.Password);
            
           

            if(result.Succeeded)
            {
                return new UserManagerResponse
                {
                    Message = "User created successfully!",
                    IsSuccess = true,
                };
            }
            return new UserManagerResponse
            {
                Message="User did not create",
                IsSuccess=false,
                Errors=result.Errors.Select(e=>e.Description)
            };
        }

         public async Task<UserManagerResponse> LoginUserAsync(LoginViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if(user == null)
            {
                return new UserManagerResponse
                {
                    Message = "There is no user with that Email address",
                    IsSuccess = false,
                };
            }

            var result = await _userManager.CheckPasswordAsync(user, model.Password);

            if(!result)
                return new UserManagerResponse
                {
                    Message = "Invalid password",
                    IsSuccess = false,
                };

            var claims = new[]
            {
                new Claim("Email", model.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthSettings:Key"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["AuthSettings:Issuer"],
                audience: _configuration["AuthSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

            string tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);

            return new UserManagerResponse
            {
                Message = tokenAsString,
                IsSuccess = true,
             
            };
        }

    }
}