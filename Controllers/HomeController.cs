using System.Linq;
using System.Web.Mvc;

namespace wake_fit2.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserProfile objUser)
        
            if (ModelState.IsValid)
            {
                using (DB_Entities db = new DB_Entities())
                {
                    var obj = db.UserProfiles.Where(a => a.UserName.Equals(objUser.UserName) && a.Password.Equals(objUser.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserID"] = obj.UserId.ToString();
                        Session["UserName"] = obj.UserName.ToString();
                        return RedirectToAction("UserDashBoard");
                    }
                }
            }
            ViewBag.Message = "Incorrect userName or Password";
            return View(objUser);
        }

        public ActionResult UserDashBoard()
        {
            if (Session["UserID"] != null)
            {
                return Redirect("~/wake-fit/wake-fit asanas/user/index.html");
                //return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult SignUp()
        {
            return RedirectToAction("Index", "NewUser");

        }
    }
}
