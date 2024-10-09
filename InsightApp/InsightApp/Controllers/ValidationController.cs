using InsightApp.Entities;
using Microsoft.AspNetCore.Mvc;

namespace InsightApp.Controllers
{
    /// <summary>
    /// A separate controller dedicated to remote validn.
    /// </summary>
    public class ValidationController : Controller
    {
        private InsightUpdateCvgs2Context _SVGSDbContext;
        public ValidationController(InsightUpdateCvgs2Context SVGSDbContext)
        {
            _SVGSDbContext = SVGSDbContext;
        }
        //public IActionResult CheckEmail(string emailAddress)
        //{
        //    Console.WriteLine($"Check email action called with email: {emailAddress}");
        //    string emailCheckMsg = CheckIfEmailExistsInDb(emailAddress);
        //    if (string.IsNullOrEmpty(emailCheckMsg))
        //    {
        //        // return (using temp data) an indication to the client that the email addr is valid
        //        TempData["okEmail"] = true;

        //        // plus return JSON true value:
        //        return Json(true);
        //    }
        //    else
        //    {
        //        // returning a msg indicating the address is already in use:
        //        return Json(emailCheckMsg);
        //    }
        //}

        //private string CheckIfEmailExistsInDb(string email)
        //{
        //    string msg = "";
        //    if (!string.IsNullOrEmpty(email))
        //    {
        //        var customer = _SVGSDbContext.Accounts.Where(c => c.EmailAddress.ToLower() == email.ToLower()).FirstOrDefault();
        //        if (customer != null)
        //            msg = $"The email address \"{email}\" is already in use.";
        //    }
        //    return msg;
        //}
    }
}
