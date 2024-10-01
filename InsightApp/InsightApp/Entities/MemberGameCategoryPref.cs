using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace InsightApp.Entities;

[Keyless]
[Table("MemberGameCategoryPref")]
public partial class MemberGameCategoryPref
{
    public int? MemberId { get; set; }

    public int? CategoryId { get; set; }

    [ForeignKey("CategoryId")]
    public virtual GameCategory? Category { get; set; }

    [ForeignKey("MemberId")]
    public virtual Member? Member { get; set; }
}
