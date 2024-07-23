using System;
using System.Collections.Generic;

namespace Enforcement_proceedings_app.Models;

public partial class Authority
{
    public int AuthorityId { get; set; }

    public string AuthorityName { get; set; } = null!;

    public string? AuthorityCode { get; set; }

    public virtual ICollection<EnforcementAgency> EnforcementAgencies { get; set; } = new List<EnforcementAgency>();
}
