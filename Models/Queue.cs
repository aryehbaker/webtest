using System;
using System.Collections.Generic;

namespace webtest.Models;

public partial class Queue
{
    public int Id { get; set; }

    public string? QueueName { get; set; }

    public virtual ICollection<QueueLabel> QueueLabels { get; set; } = new List<QueueLabel>();

    public virtual ICollection<RoleDetail> RoleDetails { get; set; } = new List<RoleDetail>();

    public virtual ICollection<Thread> Threads { get; set; } = new List<Thread>();
}
