using System;
using System.Collections.Generic;

namespace Labb2_databaser.Models;

public partial class Employee
{
    public int EmployeesId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? PersonalNumber { get; set; }

    public int? FkroleId { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}
