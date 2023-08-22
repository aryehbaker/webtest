using System;
using System.Collections.Generic;

namespace webtest.Models;

public partial class User
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public bool? Administrator { get; set; }

    public bool? Pm { get; set; }

    public virtual ICollection<Thread> ThreadAssigneeNavigations { get; set; } = new List<Thread>();

    public virtual ICollection<ThreadMessage> ThreadMessages { get; set; } = new List<ThreadMessage>();

    public virtual ICollection<Thread> ThreadUsers { get; set; } = new List<Thread>();
}
