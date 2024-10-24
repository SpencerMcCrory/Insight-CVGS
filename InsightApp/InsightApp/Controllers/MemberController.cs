using InsightApp.Components;
using InsightApp.Entities;
using InsightApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace InsightApp.Controllers
{
    public class MemberController : Controller
    {
        private InsightUpdateCvgs2Context _SVGSDbContext;
        public MemberController(InsightUpdateCvgs2Context sVGSDbContext)
        {
            _SVGSDbContext = sVGSDbContext;
        }

        //-----Portal home page ------------
        [HttpGet("Portal")]
        public IActionResult MemberPortal()
        {
            ViewBag.Page = "MemberPortal";
            ViewBag.Account = "Member";
            return View("MemberPortal");
        }


        //-----Portal My profile ------------
        [HttpGet("Portal/profile/{id}")]
        public async Task<ActionResult> MemberProfile(int id , string? activeTab = "profileTab")
        {
            ProfileViewModel profileViewModel = new ProfileViewModel();
            profileViewModel.ActiveMember = new Member();           
            profileViewModel.ActiveMember.MemberId= id;
            ViewBag.Page = "MemberPortal";
            ViewBag.Account = "Member";
            
            return View("Profile", profileViewModel);
        }

        [HttpPost("Portal/add-edit-address-requests")]
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

            return RedirectToAction("MemberProfile", "Member", new { id = memberAddressesViewModel.MemberId, activeTab = "addressTab" });
            
        }

        [HttpPost("Portal/edit-profile-requests")]
        public async Task<IActionResult> EditMemberProfileId( MemberProfileViewModel memberProfileViewModel)
        {
            memberProfileViewModel.ActiveMember.Account = _SVGSDbContext.Accounts.FirstOrDefault(a => a.Id == memberProfileViewModel.ActiveMember.AccountId);
            if (ModelState.IsValid)
            {

                // it's valid so we want to update the existing Members in the DB:
                _SVGSDbContext.Members.Update(memberProfileViewModel.ActiveMember);
                await _SVGSDbContext.SaveChangesAsync();

                TempData["LastActionMessage"] = $"The Profile has been updated.";

                return RedirectToAction("MemberProfile", "Member", new { id = memberProfileViewModel.ActiveMember.MemberId, activeTab = "profileTab" });
            }
            else
            {
                // it's invalid so we simply return the profileViewModel object
                // to the Edit view again:
                ProfileViewModel profileViewModel = new ProfileViewModel();
                profileViewModel.ActiveMember = new Member();
                profileViewModel.ActiveMember.MemberId = memberProfileViewModel.ActiveMember.MemberId;

                return View("Profile", profileViewModel);
            }

            
        }


        //-----Portal wishlist ------------
        [HttpGet("Portal/wish-list")]
        public IActionResult wishlist()
        {
            WishlistViewModel wishlistViewModel = new WishlistViewModel();
            
            //Get all item from Wishlist table include Game table ==> wishlistViewModel.WishlistItems  & wishlistViewModel.MemberId

            return View("wishlist", wishlistViewModel);
        }

        [HttpPost("Portal/wish-list/delete-requests/{gameId}/{memberId}")]
        public async Task<IActionResult> DeleteWhislistItem(int gameId, int memberId)
        {

            // from Wishlist table, Delete the record where MemberId=memberId AND  GameId=gameId

            return RedirectToAction("wishlist", "Member");

        }


        //-----Portal owned games ------------
        [HttpGet("Portal/myGames")]
        public IActionResult OwnedGames()
        {
            OwnedGamesViewModel ownedGamesViewModel = new OwnedGamesViewModel();

            //Get all item from OwnedGame table include Game table ==> ownedGamesViewModel.MyGamesItems  & ownedGamesViewModel.MemberId

            return View("OwnedGames", ownedGamesViewModel);
        }

        [HttpGet("Portal/myGames/id")]
        public IActionResult MyGame()
        {
          
            return View("MyGame");
        }


        [HttpGet("Portal/NewProfile")]
        public IActionResult NewProfile()
        {

            return View("NewProfile");
        }


        [HttpGet("Portal/NewProfile/6")]
        public async Task<ActionResult> MemberProfile2(int id)
        {
            id = 6;
            ProfileViewModel profileViewModel = new ProfileViewModel();
            profileViewModel.ActiveMember = new Member();
            profileViewModel.ActiveMember.MemberId = id;
            ViewBag.Page = "MemberPortal";
            ViewBag.Account = "Member";

            return View("NewProfile", profileViewModel);
        }



    }
}
