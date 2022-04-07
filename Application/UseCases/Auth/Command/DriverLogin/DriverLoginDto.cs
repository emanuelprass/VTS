using SceletonAPI.Application.Models.Query;

namespace SceletonAPI.Application.UseCases.Auth.Command.DriverLogin
{
    public class DriverLoginDto : BaseDto
    {
        public string TokenId { get; set; }
        public string TokenType { set; get; }
        public DriverLoginDtoData Data { set; get; }
    }

    public class DriverLoginDtoData
    {
        public int Id { get; set; }
        public string Name { set; get; }
        public string VendorName { set; get; }
        public string Status { set; get; }
    }
}
