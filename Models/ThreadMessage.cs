using System;
using System.Collections.Generic;

namespace webtest.Models;

public partial class ThreadMessage
{
    public int Id { get; set; }

    public int? ThreadId { get; set; }

    public bool? Incoming { get; set; }

    public int? UserId { get; set; }

    public int? MessageStatus { get; set; }

    public DateTime? DateOfCreation { get; set; }

    public bool? SoftDeleted { get; set; }

    public string? SoftDeleteReason { get; set; }

    public DateTime? SoftDeleteDate { get; set; }

    public virtual MessageStatus? MessageStatusNavigation { get; set; }

    public virtual Thread? Thread { get; set; }

    public virtual User? User { get; set; }
}
