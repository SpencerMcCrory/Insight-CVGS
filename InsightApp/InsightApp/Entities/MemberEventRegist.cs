using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace InsightApp.Entities;

[Keyless]
[Table("MemberEventRegist")]
public partial class MemberEventRegist
{
    public int? MemberId { get; set; }

    public int? EventId { get; set; }

    [ForeignKey("EventId")]
    public virtual GameEvent? Event { get; set; }

    [ForeignKey("MemberId")]
    public virtual Member? Member { get; set; }
}
