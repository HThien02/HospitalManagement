using System;
using System.Collections.Generic;

namespace HospitalManagement.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual ICollection<CovidInfo> CovidInfos { get; set; } = new List<CovidInfo>();

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();

    public virtual UserDetail UserNavigation { get; set; } = null!;

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
