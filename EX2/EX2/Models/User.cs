using System;
using System.Collections.Generic;

namespace EX2.Models;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Phone { get; set; }

    public virtual ICollection<Tasks> Tasks { get; set; } = new List<Tasks>();
}
