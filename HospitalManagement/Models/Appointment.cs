using System;
using System.Collections.Generic;

namespace HospitalManagement.Models;

public partial class Appointment
{
    public int AppointmentId { get; set; }

    public int? UserId { get; set; }

    public int? PatientId { get; set; }

    public int? ClinicId { get; set; }

    public DateTime? AppointmentTime { get; set; }

    public string? AppointmentStatus { get; set; }

    public virtual Clinic? Clinic { get; set; }

    public virtual ICollection<Medical> Medicals { get; set; } = new List<Medical>();

    public virtual Patient? Patient { get; set; }

    public virtual User? User { get; set; }
}
