namespace TestProject.Dtos
{
    public class UserManagerResponse
    {
         public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}