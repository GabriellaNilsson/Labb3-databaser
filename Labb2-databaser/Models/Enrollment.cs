using System;
using System.Collections.Generic;

namespace Labb2_databaser.Models;

public partial class Enrollment
{
    public string? StudentId { get; set; }

    public string? CourseId { get; set; }

    public int? GradeInfo { get; set; }

    public DateTime? DateOfGrade { get; set; }

    public virtual Course? Course { get; set; }

    public virtual Student? Student { get; set; }
}
