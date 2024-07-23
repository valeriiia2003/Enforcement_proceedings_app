using System;
using System.Collections.Generic;

namespace Enforcement_proceedings_app.Models;

public partial class Client
{
    public int ClientId { get; set; }

    public string ClientName { get; set; } = null!;

    public string? ClientSurname { get; set; }

    public string ClientAddress { get; set; } = null!;

    public string? AdditionalAddress { get; set; }

    public int CityId { get; set; }

    public string? ClientPhoneNumber { get; set; }

    public string? ClientEmail { get; set; }

    public virtual City City { get; set; } = null!;

    public virtual ICollection<Party> Parties { get; set; } = new List<Party>();
}
