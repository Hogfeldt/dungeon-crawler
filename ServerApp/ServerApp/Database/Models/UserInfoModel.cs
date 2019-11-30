using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ServerApp.Database.Models
{
    public class UserInfoModel
    {
        [Key]
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public List<CharacterModel> CharacterModels { get; set; }
    }
}