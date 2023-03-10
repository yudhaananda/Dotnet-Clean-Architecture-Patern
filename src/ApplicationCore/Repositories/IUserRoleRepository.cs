﻿using ApplicationCore.Filters;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Repositories
{
    public interface IUserRoleRepository : IAsyncRepository<UserRole, UserRoleFilter>
    {
    }
}
