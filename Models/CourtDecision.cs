using System;
using System.Collections.Generic;

namespace Enforcement_proceedings_app.Models;

public partial class CourtDecision
{
    public int DecisionId { get; set; }

    public int ExecutiveCaseId { get; set; }

    public DateTime? DecisionDate { get; set; }

    public string AddtionalText { get; set; } = null!;

    public virtual ICollection<ExecutiveAction> ExecutiveActions { get; set; } = new List<ExecutiveAction>();

    public virtual ExecutiveCase ExecutiveCase { get; set; } = null!;
}
