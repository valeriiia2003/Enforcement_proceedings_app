using System;
using System.Collections.Generic;

namespace Enforcement_proceedings_app.Models;

public partial class ExecutiveCase
{
    public int CaseId { get; set; }

    public string CaseNumber { get; set; } = null!;

    public string DescriptionText { get; set; } = null!;

    public DateTime? FillingDate { get; set; }

    public string? CaseStatus { get; set; }

    public virtual ICollection<ClientsCase> ClientsCases { get; set; } = new List<ClientsCase>();

    public virtual ICollection<CourtDecision> CourtDecisions { get; set; } = new List<CourtDecision>();
}
