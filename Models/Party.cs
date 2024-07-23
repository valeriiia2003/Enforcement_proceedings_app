using System;
using System.Collections.Generic;

namespace Enforcement_proceedings_app.Models;

public partial class Party
{
    public int PartieId { get; set; }

    public int? ClientId { get; set; }

    public int PtypeId { get; set; }

    public virtual Client? Client { get; set; }

    public virtual ICollection<ClientsCase> ClientsCases { get; set; } = new List<ClientsCase>();

    public virtual ParticipantsType Ptype { get; set; } = null!;
}
