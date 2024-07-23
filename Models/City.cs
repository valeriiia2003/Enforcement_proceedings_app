using System;
using System.Collections.Generic;

namespace Enforcement_proceedings_app.Models;

public partial class City
{
    public int CityId { get; set; }

    public string CityName { get; set; } = null!;

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();
}
