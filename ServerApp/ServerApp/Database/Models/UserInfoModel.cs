namespace ServerApp.Database.Models
{
    public class UserInfoModel
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int[] Characters { get; set; }
    }
}