using System;
using System.Collections.Generic;

namespace Enforcement_proceedings_app.Models;

public partial class EnforcementAgency
{
    public int AgencyId { get; set; }

    public string AgencyName { get; set; } = null!;

    public string? AgencySurname { get; set; }

    public int AuthId { get; set; }

    public virtual Authority Auth { get; set; } = null!;

    public virtual ICollection<ExecAuthor> ExecAuthors { get; set; } = new List<ExecAuthor>();
}
