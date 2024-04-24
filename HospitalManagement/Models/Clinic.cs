using System;
using System.Collections.Generic;

namespace HospitalManagement.Models;

public partial class Clinic
{
    public int ClinicId { get; set; }

    public string? ClinicName { get; set; }

    public string? Description { get; set; }

    public string? Service { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
