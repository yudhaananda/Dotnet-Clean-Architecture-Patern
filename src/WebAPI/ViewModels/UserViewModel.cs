using ApplicationCore.Models;

namespace WebAPI.ViewModels
{
    public class UserViewModel : BaseVIewModel
    {
        public int? Id { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public virtual ICollection<UserRoleViewModel> UserRoles { get; set; }
    }
}
