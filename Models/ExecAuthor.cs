using System;
using System.Collections.Generic;

namespace Enforcement_proceedings_app.Models;

public partial class ExecAuthor
{
    public int FinalcaseId { get; set; }

    public int AgencyId { get; set; }

    public int ExActionId { get; set; }

    public virtual EnforcementAgency Agency { get; set; } = null!;

    public virtual ExecutiveAction ExAction { get; set; } = null!;
}
