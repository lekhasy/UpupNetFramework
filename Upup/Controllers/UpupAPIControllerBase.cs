using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Upup.Models;
using Microsoft.AspNet.Identity.Owin;
using System.Web.Http;
using System.Web.Http.Owin;
using System.Net.Http;

namespace Upup.Controllers
{
    [System.Web.Http.Authorize]
    public class UpupAPIControllerBase : ApiController
    {
        private ApplicationDbContext _db;
        private ApplicationUserManager _userManager;
        private ApplicationRoleManager _roleManager;
        private ApplicationSignInManager _signInManager;

        public UpupAPIControllerBase()
        {
        }

        public UpupAPIControllerBase(ApplicationDbContext db,
        ApplicationUserManager userManager,
        ApplicationRoleManager roleManager,
        ApplicationSignInManager signInManager)
        {
            Db = db;
            UserManager = userManager;
            RoleManager = roleManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>();
            }

            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ApplicationDbContext Db
        {
            get
            {
                return _db ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationDbContext>();
            }
            private set
            {
                _db = value;
            }
        }

        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.Current.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }
                

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }

                if (_db != null)
                {
                    _db.Dispose();
                    _db = null;
                }

                if (_roleManager != null)
                {
                    _roleManager.Dispose();
                    _roleManager = null;
                }

            }

            base.Dispose(disposing);
        }
    }
}