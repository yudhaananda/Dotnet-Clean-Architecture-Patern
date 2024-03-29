﻿namespace WebAPI.ViewModels
{
    public class RoleViewModel : BaseVIewModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<UserRoleViewModel>? UserRoles { get; set; }
    }
}
