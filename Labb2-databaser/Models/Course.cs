using System;
using System.Collections.Generic;

namespace Labb2_databaser.Models;

public partial class Course
{
    public string CourseId { get; set; } = null!;

    public string? CourseName { get; set; }

    public string? Classroom { get; set; }

    public int? FkemployeeId { get; set; }

    public virtual Employee? Fkemployee { get; set; }
}
