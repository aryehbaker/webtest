using System;
using System.Collections.Generic;

namespace webtest.Models;

public partial class PermissionType
{
    public int Id { get; set; }

    public string? Permission { get; set; }

    public virtual ICollection<RoleDetail> RoleDetails { get; set; } = new List<RoleDetail>();
}
