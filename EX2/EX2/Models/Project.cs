using System;
using System.Collections.Generic;

namespace EX2.Models;

public partial class Project
{
    public int Id { get; set; }

    public string ProjectName { get; set; } = null!;

    public virtual ICollection<Tasks> Tasks { get; set; } = new List<Tasks>();
}
