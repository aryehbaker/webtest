using System;
using System.Collections.Generic;

namespace webtest.Models;

public partial class ThreadStatus
{
    public int Id { get; set; }

    public string? StatusName { get; set; }

    public virtual ICollection<Thread> Threads { get; set; } = new List<Thread>();
}
