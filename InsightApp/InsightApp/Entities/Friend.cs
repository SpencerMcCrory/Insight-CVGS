using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace InsightApp.Entities;

[Keyless]
[Table("Friend")]
public partial class Friend
{
    public int? MemberId { get; set; }

    public int? FriendId { get; set; }

    [ForeignKey("FriendId")]
    public virtual Member? FriendNavigation { get; set; }

    [ForeignKey("MemberId")]
    public virtual Member? Member { get; set; }
}
