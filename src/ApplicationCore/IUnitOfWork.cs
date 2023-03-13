using ApplicationCore.Repositories;

namespace ApplicationCore
{
    public interface IUnitOfWork
    {
        IUserRepository User { get; }
        IUserRoleRepository UserRole { get; }
        IRoleRepository Role { get; }
    }
}
