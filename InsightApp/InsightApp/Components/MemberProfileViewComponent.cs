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
            var member =await  _SVGSDbContext.Members
                .Where(e => e.MemberId == memberId).FirstOrDefaultAsync();
            
            MemberProfileViewModel memberProfileViewModel = new MemberProfileViewModel()
            {
                ActiveMember = member,
            };

            return View(memberProfileViewModel);
        }
    }
}
