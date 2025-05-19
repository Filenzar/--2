using System;
using System.Collections.Generic;

namespace _19._05._25ContolW.Models;

public partial class Request
{
    public int Article { get; set; }

    public string? Description { get; set; }

    public string? FulDescription { get; set; }

    public DateOnly? DateRegistration { get; set; }

    public string? UserReq { get; set; }

    public string TypeReq { get; set; } = null!;

    public string StatusReq { get; set; } = null!;

    public virtual StatusRequest StatusReqNavigation { get; set; } = null!;

    public virtual TypeRequest TypeReqNavigation { get; set; } = null!;

    public virtual User? UserReqNavigation { get; set; }
}
