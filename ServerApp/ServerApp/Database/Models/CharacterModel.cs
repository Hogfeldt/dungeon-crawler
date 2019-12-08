using System.ComponentModel.DataAnnotations.Schema;

namespace ServerApp.Database.Models
{
    public class CharacterModel
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Sprite { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Color { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Username { get; set; }
        public virtual UserInfoModel UserInfoModel { get; set; }
    }
}