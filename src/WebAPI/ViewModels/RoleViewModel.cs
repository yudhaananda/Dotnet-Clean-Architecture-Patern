using ApplicationCore.Models;

namespace WebAPI.ViewModels
{
    public class RoleViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<UserRoleViewModel> UserRoles { get; set; }
    }
}
