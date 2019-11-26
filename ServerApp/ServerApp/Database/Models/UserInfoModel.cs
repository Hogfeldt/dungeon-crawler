using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ServerApp.Database.Models
{
    public class UserInfoModel
    {
        public long Id { get; set; }

        [Key]
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}