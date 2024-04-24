using System;
using System.Collections.Generic;

namespace HospitalManagement.Models;

public partial class UserDetail
{
    public int UserId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Gender { get; set; }

    public DateTime? Birthday { get; set; }

    public double? Salary { get; set; }

    public virtual User? User { get; set; }
}
