using InsightApp.Entities;
using InsightApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace InsightApp.Controllers
{
    public class MemberController : Controller
    {
        private SVGSDbContext _SVGSDbContext;
        public MemberController(SVGSDbContext sVGSDbContext)
        {
            _SVGSDbContext = sVGSDbContext;
        }
        public ActionResult MemberPortal()
        {
            ViewBag.Page = "MemberPortal";
            ViewBag.Account = "Guest";
            return View("MemberPortal");
        }
        
        [HttpGet("/members/{id}")]
        public ActionResult MemberProfile(int id)
        {
            var member = _SVGSDbContext.Members
                .Include(e => e.Account)
                .Include(e => e.AddressTables)
                .Where(e => e.MemberId == id).FirstOrDefault();
            
            var addr= member.AddressTables.Where(a => a.IsShipping==false).FirstOrDefault();
            var addrShipping = member.AddressTables.Where(a => a.IsShipping == true).FirstOrDefault();

            bool areEqual = AreAddressEqual(addr, addrShipping);
            ViewBag.AddressesAreEqual= AreAddressEqual(addr, addrShipping);
            ProfileViewModel profileViewModel = new ProfileViewModel()
            {
                ActiveMember= member,
                MemberAddress = addr,
                ShippingAddress = addrShipping

            };

            string str1 = addr.ToString();
            string str2= addrShipping.ToString();
            if (str1==str2)
            {
                bool x = true;
            }

            ViewBag.Page = "MemberPortal";
            ViewBag.Account = "Member";
            return View("Profile", profileViewModel);
        }


        public static bool AreAddressEqual<T>(T obj1, T obj2)
        {
            // If one object is null and the other is not, they are not equal
            if (obj1 == null || obj2 == null)
                return false;

            // Get all the public properties of the objects
            PropertyInfo[] properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo property in properties)
            {
                if (property.Name== "StreetName" || property.Name == "StreetNumber"
                    || property.Name == "Unit" || property.Name == "PostalCode"
                    || property.Name == "City" || property.Name == "Province"|| property.Name == "Country")
                {
                    object value1 = property.GetValue(obj1);
                    object value2 = property.GetValue(obj2);

                    // Check if values are not equal
                    if (!Equals(value1, value2))
                    {
                        return false;
                    }
                } 
            }

            return true; // All properties are equal
        }





    }
}
