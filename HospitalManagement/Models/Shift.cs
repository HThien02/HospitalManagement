using System;
using System.Collections.Generic;

namespace HospitalManagement.Models;

public partial class Shift
{
    public int ShiftId { get; set; }

    public string? ShiftName { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public virtual ICollection<ShiftShedule> ShiftShedules { get; set; } = new List<ShiftShedule>();
}
