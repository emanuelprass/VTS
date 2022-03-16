namespace SceletonAPI.Application.Models.Auth
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public string UserRole { get; set; }
        public string Password { get; set; }
        public string RowStatus { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedTime { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedTime { get; set; }
    }
}
