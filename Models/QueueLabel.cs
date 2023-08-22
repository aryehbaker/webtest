using System;
using System.Collections.Generic;

namespace webtest.Models;

public partial class QueueLabel
{
    public int Id { get; set; }

    public string? LabelName { get; set; }

    public int? QueueId { get; set; }

    public bool? ThreadLabel { get; set; }

    public bool? MessageLable { get; set; }

    public virtual Queue? Queue { get; set; }
}
