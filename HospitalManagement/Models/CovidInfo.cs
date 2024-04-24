using System;
using System.Collections.Generic;

namespace HospitalManagement.Models;

public partial class CovidInfo
{
    public int CovidId { get; set; }

    public int? UserId { get; set; }

    public DateTime? TestDate { get; set; }

    public string? TestResult { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? VaccineStatus { get; set; }

    public virtual User? User { get; set; }
}
