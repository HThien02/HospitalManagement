using System;
using System.Collections.Generic;

namespace HospitalManagement.Models;

public partial class ShiftShedule
{
    public int ShiftScheduleId { get; set; }

    public int? ShiftId { get; set; }

    public int? ScheduleId { get; set; }

    public virtual Schedule? Schedule { get; set; }

    public virtual Shift? Shift { get; set; }
}
