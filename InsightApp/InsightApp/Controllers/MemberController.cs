using InsightApp.Components;
using InsightApp.Entities;
using InsightApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace InsightApp.Controllers
{
    public class MemberController : Controller
    {
        private InsightUpdateCvgs2Context _SVGSDbContext;
        public MemberController(InsightUpdateCvgs2Context sVGSDbContext)
        {
            _SVGSDbContext = sVGSDbContext;
        }
        public ActionResult MemberPortal()
        {
            ViewBag.Page = "MemberPortal";
            ViewBag.Account = "Member";
            return View("MemberPortal");
        }
        
        [HttpGet("/members/{id}")]
        public async Task<ActionResult> MemberProfile(int id)
        {
            ProfileViewModel profileViewModel = new ProfileViewModel();
            profileViewModel.ActiveMember = new Member();           
            profileViewModel.ActiveMember.MemberId= id;
            ViewBag.Page = "MemberPortal";
            ViewBag.Account = "Member";
            
            return View("Profile", profileViewModel);
        }

        [HttpPost("/add-edit-address-requests")]
        public async Task<IActionResult> AddAddressesById(MemberAddressesViewModel memberAddressesViewModel)
        {
            //----Member Address------
            AddressTable memberAdr = memberAddressesViewModel.MemberAddress;
            memberAdr.MemberId = memberAddressesViewModel.MemberId;
            
            //-----Shipping Address-----
            AddressTable shippingAdr = memberAddressesViewModel.ShippingAddress;
            shippingAdr.MemberId = memberAddressesViewModel.MemberId;


            //if same address checked copy the main properies will be the same
            if (memberAddressesViewModel.IsAdressesSame == true) 
            {
                shippingAdr.Unit=memberAdr.Unit;
                shippingAdr.StreetNumber=memberAdr.StreetNumber;
                shippingAdr.StreetName=memberAdr.StreetName;
                shippingAdr.City=memberAdr.City;
                shippingAdr.PostalCode=memberAdr.PostalCode;
                shippingAdr.Province=memberAdr.Province;
                shippingAdr.Country=memberAdr.Country;
            }


            //if new addresses, create new address records ( MemberAddress => isShipping=false + ShippingAddress=> isShipping=true)
            if (memberAdr.AddressId == 0 && shippingAdr.AddressId == 0)
            {
                // it's valid so we want to add the new address to the DB ((Member Address)):
                await _SVGSDbContext.AddressTables.AddAsync(memberAdr);
                await _SVGSDbContext.SaveChangesAsync();

                // it's valid so we want to add the new address to the DB ((Shipping Address)):
                await _SVGSDbContext.AddressTables.AddAsync(shippingAdr);
                await _SVGSDbContext.SaveChangesAsync();

                TempData["LastActionMessage"] = $"The Adress is successfully Added";
            }
            else
            {
                // it's valid so we want to add the new address to the DB ((Member Address)):
                _SVGSDbContext.AddressTables.Update(memberAdr);
                await _SVGSDbContext.SaveChangesAsync();

                // it's valid so we want to add the new address to the DB ((Shipping Address)):
                _SVGSDbContext.AddressTables.Update(shippingAdr);
                await _SVGSDbContext.SaveChangesAsync();

                TempData["LastActionMessage"] = $"The Adress is successfully updated";

            }

            return RedirectToAction("MemberProfile", "Member", new { id = memberAddressesViewModel.MemberId });
            
        }

        [HttpPost("/edit-profile-requests")]
        public async Task<IActionResult> EditMemberProfileId( MemberProfileViewModel memberProfileViewModel)
        {

            if (ModelState.IsValid)
            {

                // it's valid so we want to update the existing Members in the DB:
                _SVGSDbContext.Members.Update(memberProfileViewModel.ActiveMember);
                await _SVGSDbContext.SaveChangesAsync();

                TempData["LastActionMessage"] = $"The Profile has been updated.";

                return RedirectToAction("MemberProfile", "Member", new { id = memberProfileViewModel.ActiveMember.MemberId });
            }
            else
            {
                // it's invalid so we simply return the memberProfileViewModel object
                // to the Edit view again:

                return View("Profile", memberProfileViewModel.ActiveMember.MemberId);
            }

            
        }

        [HttpPost("/createMember")]
        public async Task<IActionResult> CreateMember(string displayName, Guid accountId)
        {
            Member newMember = new Member()
            {
                DisplayName = displayName,
                AccountId = accountId
            };

            // it's valid so we want to update the existing Members in the DB:
            await _SVGSDbContext.Members.AddAsync(newMember);
            await _SVGSDbContext.SaveChangesAsync();

            var lastMember = _SVGSDbContext.Members
                                 .OrderByDescending(m => m.MemberId)
                                 .FirstOrDefault();

            return RedirectToAction("MemberProfile", "Member", new { id = lastMember.MemberId });

        }



    }
}
