using System;
using System.Collections.Generic;

namespace HospitalManagement.Models;

public partial class Patient
{
    public int PatientId { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual PatientDetail PatientNavigation { get; set; } = null!;
}
