using System;
using System.Collections.Generic;

namespace webtest.Models;

public partial class RoleDetail
{
    public int Id { get; set; }

    public int? RolesId { get; set; }

    public int? QueuePermission { get; set; }

    public int? PermissionType { get; set; }

    public virtual PermissionType? PermissionTypeNavigation { get; set; }

    public virtual Queue? QueuePermissionNavigation { get; set; }

    public virtual Role? Roles { get; set; }
}
