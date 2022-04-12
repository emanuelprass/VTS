using SceletonAPI.Application.Models.Query;

namespace SceletonAPI.Application.UseCases.Auth.Command.Driver.RequestOTP
{
    public class RequestOTPDto : BaseDto
    {
        public RequestOTPDtoData Data { set; get; }
    }

    public class RequestOTPDtoData
    {
		public string Phone { get; set; }
        public int? OTP { get; set; }
    }
}
