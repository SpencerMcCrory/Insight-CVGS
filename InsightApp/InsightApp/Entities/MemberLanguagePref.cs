using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace InsightApp.Entities;

[Keyless]
[Table("MemberLanguagePref")]
public partial class MemberLanguagePref
{
    public int? MemberId { get; set; }

    public int? LanguageId { get; set; }

    [ForeignKey("LanguageId")]
    public virtual LanguageTable? Language { get; set; }

    [ForeignKey("MemberId")]
    public virtual Member? Member { get; set; }
}
