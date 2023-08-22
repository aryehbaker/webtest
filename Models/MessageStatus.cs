using System;
using System.Collections.Generic;

namespace webtest.Models;

public partial class MessageStatus
{
    public int Id { get; set; }

    public string? StatusName { get; set; }

    public virtual ICollection<ThreadMessage> ThreadMessages { get; set; } = new List<ThreadMessage>();
}
