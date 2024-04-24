using System;
using System.Collections.Generic;

namespace HospitalManagement.Models;

public partial class Medical
{
    public int MedicalId { get; set; }

    public int? AppointmentId { get; set; }

    public DateTime? ExaminationDate { get; set; }

    public string? Symptoms { get; set; }

    public string? Diagnosis { get; set; }

    public string? Prescription { get; set; }

    public virtual Appointment? Appointment { get; set; }
}
