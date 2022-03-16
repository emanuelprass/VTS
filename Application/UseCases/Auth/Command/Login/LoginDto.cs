using SceletonAPI.Application.Models.Query;

namespace SceletonAPI.Application.UseCases.Auth.Command.Login
{
    public class LoginDto : BaseDto
    {
        public string TokenId { get; set; }
        public string TokenType { set; get; }
        public LoginDtoData Data { set; get; }
    }

    public class LoginDtoData
    {
        public int Id { get; set; }
        public string Name { set; get; }
        public string Company { set; get; }
        public string Role { set; get; }
    }
}
