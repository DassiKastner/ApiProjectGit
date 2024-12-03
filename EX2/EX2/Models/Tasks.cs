using System;
using System.Collections.Generic;

namespace EX2.Models;

public partial class Tasks
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Date { get; set; }

    public string? Status { get; set; }

    public int ProjectId { get; set; }

    public int UserId { get; set; }

    public virtual Project Project { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
