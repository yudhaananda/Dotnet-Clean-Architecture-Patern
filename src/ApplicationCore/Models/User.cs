using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Models
{
    public class User : BaseModel<User>
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public virtual ICollection<UserRole>? UserRoles { get; set; }

        public override void Edit(User user)
        {
            UserName = user.UserName;
            Password = user.Password;
            UpdatedDate = DateTime.Now;
            UpdatedById = user.Id;
        }
    }
}
