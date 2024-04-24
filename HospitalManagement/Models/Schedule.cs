using System;
using System.Collections.Generic;

namespace HospitalManagement.Models;

public partial class Schedule
{
    public int ScheduleId { get; set; }

    public int? UserId { get; set; }

    public DateTime? WorkDate { get; set; }

    public int? WorkHours { get; set; }

    public int? OverTimeHours { get; set; }

    public virtual ICollection<ShiftShedule> ShiftShedules { get; set; } = new List<ShiftShedule>();

    public virtual User? User { get; set; }
}
