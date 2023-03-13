namespace WebAPI.ViewModels
{
    public class UserRoleViewModel : BaseVIewModel
    {
        public int? Id { get; set; }
        public int UserId { get; set; }
        public virtual UserViewModel? User { get; set; }
        public int RoleId { get; set; }
        public virtual RoleViewModel? Role { get; set; }
    }
}
