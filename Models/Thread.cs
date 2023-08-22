using System;
using System.Collections.Generic;

namespace webtest.Models;

public partial class Thread
{
    public int Id { get; set; }

    public int? QueueId { get; set; }

    public string? Summary { get; set; }

    public string? Resolution { get; set; }

    public int? Assignee { get; set; }

    public int? UserId { get; set; }

    public int? ThreadStatus { get; set; }

    public DateTime? DateOfCreation { get; set; }

    public bool? SoftDeleted { get; set; }

    public string? SoftDeleteReason { get; set; }

    public DateTime? SoftDeleteDate { get; set; }

    public virtual User? AssigneeNavigation { get; set; }

    public virtual Queue? Queue { get; set; }

    public virtual ICollection<ThreadMessage> ThreadMessages { get; set; } = new List<ThreadMessage>();

    public virtual ThreadStatus? ThreadStatusNavigation { get; set; }

    public virtual User? User { get; set; }
}
