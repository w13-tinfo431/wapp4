using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibrarySystem.Controllers
{

    [Authorize]
    public class TestController : Controller
    {
        // GET: Test  
        public ActionResult Identity()
        {
            return Content("We are using Identity");
        }
        /// <summary>  
        /// Disable identity to particuler action result  
        /// </summary>  
        /// <returns></returns>  
        [AllowAnonymous]
        public ActionResult NonIdentiy()
        {
            return Content("We are not using Identity");
        }
    }
} 