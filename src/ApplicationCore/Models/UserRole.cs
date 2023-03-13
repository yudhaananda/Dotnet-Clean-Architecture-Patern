using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Models
{
    public class UserRole : BaseModel<UserRole>
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual User? User { get; set; }
        public int RoleId { get; set; }
        public virtual Role? Role { get; set; }

        public override void Edit(UserRole entity)
        {
            UserId = entity.UserId;
            RoleId = entity.RoleId;
            UpdatedDate = DateTime.Now;
        }
    }
}
