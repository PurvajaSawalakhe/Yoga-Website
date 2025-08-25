using System.Data.SqlClient;
using System.Web.Mvc;

namespace wake_fit2.Controllers
{
    public class NewUserController : Controller
    {
        // GET: NewUser
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(NewUser newUser)
        {
            if (ModelState.IsValid)
            {
                using (DB_Entities db = new DB_Entities())
                {
                    var sql = "insert into NewUser values ( @UserName, @Password, @Gender, @Contact_no, @Age, @Height, @Weight)";
                    var SqlCommend = "insert into UserProfile values ( @UserName, @Password, @IsActive)";

                    db.Database.ExecuteSqlCommand(sql, new SqlParameter("UserName", newUser.UserName), new SqlParameter("Password", newUser.Password), new SqlParameter("Gender", newUser.Gender), new SqlParameter("Contact_no", newUser.Contact_no), new SqlParameter("Age", newUser.Age), new SqlParameter("Height", newUser.Height), new SqlParameter("Weight", newUser.Weight));
                    db.Database.ExecuteSqlCommand(SqlCommend, new SqlParameter("UserName", newUser.UserName), new SqlParameter("Password", newUser.Password), new SqlParameter("IsActive", 1));
                    return Content("User create Successfully !");
                }
            }
            return View();
        }
    }
}