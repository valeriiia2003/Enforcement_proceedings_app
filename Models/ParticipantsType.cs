using System;
using System.Collections.Generic;

namespace Enforcement_proceedings_app.Models;

public partial class ParticipantsType
{
    public int ParticipantTypeId { get; set; }

    public string ParticipantType { get; set; } = null!;

    public virtual ICollection<Party> Parties { get; set; } = new List<Party>();
}
