﻿using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealSite.Presentation.Identity.Roles.Queries.GerRolles.GetAllRoles
{
    public class GetAllRolesQuery : IRequest<RoleListVm>
    {

    }
}