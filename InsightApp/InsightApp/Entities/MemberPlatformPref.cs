using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace InsightApp.Entities;

[Keyless]
[Table("MemberPlatformPref")]
public partial class MemberPlatformPref
{
    public int? MemberId { get; set; }

    public int? PlatformId { get; set; }

    [ForeignKey("MemberId")]
    public virtual Member? Member { get; set; }

    [ForeignKey("PlatformId")]
    public virtual GamePlatform? Platform { get; set; }
}
