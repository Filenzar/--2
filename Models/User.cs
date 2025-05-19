using System;
using System.Collections.Generic;

namespace _19._05._25ContolW.Models;

public partial class User
{
    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateOnly DateRegistration { get; set; }

    public string? Fio { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();
}
