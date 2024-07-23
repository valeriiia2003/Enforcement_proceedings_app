using System;
using System.Collections.Generic;

namespace Enforcement_proceedings_app.Models;

public partial class ClientsCase
{
    public int ClientExecutivecaseId { get; set; }

    public int ExecCaseId { get; set; }

    public int PartpId { get; set; }

    public virtual ExecutiveCase ExecCase { get; set; } = null!;

    public virtual Party Partp { get; set; } = null!;
}
