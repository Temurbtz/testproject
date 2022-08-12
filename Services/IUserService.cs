using TestProject.Dtos;

namespace TestProject.Services
{
    public interface IUserService
    {
          Task<UserManagerResponse> RegisterUserAsync(RegisterViewModel model); 
         
            Task<UserManagerResponse> LoginUserAsync(LoginViewModel model);
    }
    
}