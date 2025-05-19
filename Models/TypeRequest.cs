using System;
using System.Collections.Generic;

namespace _19._05._25ContolW.Models;

public partial class TypeRequest
{
    public string Type { get; set; } = null!;

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();
}
