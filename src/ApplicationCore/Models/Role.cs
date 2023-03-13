using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Models
{
    public class Role : BaseModel<Role>
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<UserRole>? UserRoles { get; set; }

        public override void Edit(Role entity)
        {
            Name = entity.Name;
            UpdatedDate = DateTime.Now;
        }
    }
}
