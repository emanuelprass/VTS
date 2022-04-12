using SceletonAPI.Application.Models.Query;

namespace SceletonAPI.Application.UseCases.Auth.Command.Driver.Activate
{
    public class ActivateDto : BaseDto
    {
        public ActivateDtoData Data { set; get; }
    }

    public class ActivateDtoData
    {
        public string Message { set; get; }
    }
}
