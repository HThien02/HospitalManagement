using System;
using System.Collections.Generic;

namespace HospitalManagement.Models;

public partial class PatientDetail
{
    public int PatientId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Gender { get; set; }

    public DateTime? Birthday { get; set; }

    public DateTime? ExaminationDate { get; set; }

    public string? Symptoms { get; set; }

    public string? Diagnosis { get; set; }

    public string? Prescription { get; set; }

    public virtual Patient? Patient { get; set; }
}
