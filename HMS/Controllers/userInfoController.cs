using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HMS.Models;
using HMS.Repository;

namespace HMS.Controllers
{
    public class userInfoController : Controller
    {
        
        // GET: userInfo
        public ActionResult Index(userInfo ui)
        {
            var unitOfWork = new UnitOfWork.UnitOfWork(new ApplicationDbContext());
                
            unitOfWork.UserInfo.Insert(ui);
            unitOfWork.Complete();
            return RedirectToAction("Index","patients");
        }
    }
}