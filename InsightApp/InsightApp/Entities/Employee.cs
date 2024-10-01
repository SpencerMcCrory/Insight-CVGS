using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace InsightApp.Entities;

[Table("Employee")]
[Index("AccountId", Name = "UQ__Employee__349DA5A75FB07791", IsUnique = true)]
public partial class Employee
{
    [Key]
    public int EmployeeId { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? FirstName { get; set; }

    [StringLength(25)]
    [Unicode(false)]
    public string? LastName { get; set; }

    public int? AccountId { get; set; }

    [ForeignKey("AccountId")]
    [InverseProperty("Employee")]
    public virtual Account? Account { get; set; }
}
