namespace ServerApp.Database.Models
{
    public class CharacterModel
    {
        public int Id { get; set; }
        public string Sprite { get; set; }
        public string Color { get; set; }
        public string UserName { get; set; }
        public virtual UserInfoModel UserInfoModel { get; set; }
    }
}