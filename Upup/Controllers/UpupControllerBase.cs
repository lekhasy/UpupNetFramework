﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Upup.Models;
using Microsoft.AspNet.Identity.Owin;

namespace Upup.Controllers
{
    [Authorize(Roles = "Customer")]
    public class UpupControllerBase : Controller
    {
        private ApplicationDbContext _db;
        private ApplicationUserManager _userManager;
        private ApplicationRoleManager _roleManager;
        private ApplicationSignInManager _signInManager;

        public UpupControllerBase()
        {
        }

        public UpupControllerBase(ApplicationDbContext db,
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
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
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
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
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
                return _db ?? HttpContext.GetOwinContext().GetUserManager<ApplicationDbContext>();
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
                return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
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