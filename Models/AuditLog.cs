using System;
using System.Collections.Generic;

namespace webtest.Models;

public partial class AuditLog
{
    public int Id { get; set; }

    public string? Category { get; set; }

    public string? TableName { get; set; }

    public string PrimaryKey { get; set; } = null!;

    public string? Summary { get; set; }

    public string? Details { get; set; }

    public string? Overwritten { get; set; }

    public string? EndResults { get; set; }
}
