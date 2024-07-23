using System;
using System.Collections.Generic;

namespace Enforcement_proceedings_app.Models;

public partial class ExecutiveAction
{
    public int ActionId { get; set; }

    public int DecisionId { get; set; }

    public DateTime? ExecutionDate { get; set; }

    public string ActionTaken { get; set; } = null!;

    public double? Compensation { get; set; }

    public virtual CourtDecision Decision { get; set; } = null!;

    public virtual ICollection<ExecAuthor> ExecAuthors { get; set; } = new List<ExecAuthor>();
}
