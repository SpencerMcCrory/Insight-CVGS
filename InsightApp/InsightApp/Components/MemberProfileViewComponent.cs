using InsightApp.Entities;
using InsightApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InsightApp.Components
{
    public class MemberProfileViewComponent : ViewComponent
    {
        private SVGSDbContext _SVGSDbContext;
        public MemberProfileViewComponent(SVGSDbContext sVGSDbContext)
        {
            _SVGSDbContext = sVGSDbContext;
        }

        public async Task<IViewComponentResult> InvokeAsync(int memberId)
        {
            var member =await  _SVGSDbContext.Members
                .Include(e => e.Account)
                .Where(e => e.MemberId == memberId).FirstOrDefaultAsync();
            
            MemberProfileViewModel memberProfileViewModel = new MemberProfileViewModel()
            {
                ActiveMember = member,
            };

            return View(memberProfileViewModel);
        }
    }
}
