using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ServerApp.Database.Models
{
    public class UserInfoModel
    {
        [Key]
        [Column(TypeName = "varchar(50)")]
        public string Username { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Password { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Email { get; set; }

        public List<CharacterModel> CharacterModels { get; set; }
    }
}