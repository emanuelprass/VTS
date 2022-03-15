namespace SceletonAPI.Application.Interfaces.Authorization
{
    public interface IAuthUser
    {
        public string name { set; get; }
        public string company { set; get; }
        public string role { set; get; }
        public int expired { set; get; }
        public string token { set; get; }
    }
}
