using InsightApp.Entities;
using InsightApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InsightApp.Components
{
    public class MemberProfileViewComponent : ViewComponent
    {
        private InsightUpdateCvgs2Context _SVGSDbContext;
        public MemberProfileViewComponent(InsightUpdateCvgs2Context sVGSDbContext)
        {
            _SVGSDbContext = sVGSDbContext;
        }

        public async Task<IViewComponentResult> InvokeAsync(int memberId)
        {
            var member = await  _SVGSDbContext.Members
                .FirstOrDefaultAsync(m => m.MemberId == memberId);
            var account = await _SVGSDbContext.Accounts
                .FirstOrDefaultAsync(a => a.Id == member.AccountId);
            
            MemberProfileViewModel memberProfileViewModel = new MemberProfileViewModel()
            {
                ActiveMember = member,
                ActiveMemberUsername = account.UserName,
            };

            return View(memberProfileViewModel);
        }
    }
}
