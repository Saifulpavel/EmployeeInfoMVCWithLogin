using MvcCRUDWithLogin.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcCRUDWithLogin.Controllers
{
    public class UserController : Controller
    {
        [HandleError]
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        //Registration Action
        [HttpGet]
        public ActionResult Registration()
        {
            DBModel con = new DBModel();
            User ouser = new User();
            
            ViewBag.RoleId = new SelectList(con.Roles, "RoleID", "Name", ouser.RoleID);
            return View();
        }

        //Registration POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration([Bind()] User user)
        {
            bool Status = false;
            string Message = "";

            //Model Validation
            if (ModelState.IsValid)
            {
                #region If Email Exist
                var isExist =IsEmailExist(user.EmailID);
                if (isExist)
                {
                    ModelState.AddModelError("EmailExist","Email Already Exist!");
                    return View(user);
                }
                #endregion

                #region Password Hashing
                user.Password = Encryption.Hash(user.Password);
                user.ConfirmPassword = Encryption.Hash(user.ConfirmPassword);
                #endregion

                #region Save to database
                DBModel con = new DBModel();                
                con.Users.Add(user);
                con.SaveChanges();
                Message = "Registration Successful";
                
                #endregion
            }
            else
            {
                Message = "Invalid Request";
            }
            ViewBag.Message = Message;
            ViewBag.Status = Status;
            return RedirectToAction("Login");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        //Login POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLogin login, string ReturnUrl = "")
        {
            string message = "";
            using (DBModel con = new DBModel())
            {
                var v = con.Users.Where(a => a.EmailID == login.EmailID).FirstOrDefault();
                if (v != null)
                {
                    if (string.Compare(Encryption.Hash(login.Password), v.Password) == 0)
                    {
                        int timeout = login.RememberMe ? 525600 : 20; // 525600 min = 1 year
                        var ticket = new FormsAuthenticationTicket(login.EmailID, login.RememberMe, timeout);
                        string encrypted = FormsAuthentication.Encrypt(ticket);
                        var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                        cookie.Expires = DateTime.Now.AddMinutes(timeout);
                        cookie.HttpOnly = true;
                        Response.Cookies.Add(cookie);
                        System.Web.HttpContext.Current.Session["Id"] = v.UserID.ToString();
                        System.Web.HttpContext.Current.Session["name"] ="Welcome "+ (v.FirstName+" "+v.LastName).ToString();
                        System.Web.HttpContext.Current.Session["RoleID"] = v.RoleID.ToString();
                        if (Url.IsLocalUrl(ReturnUrl))
                        {
                            return Redirect(ReturnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Employee");
                        }
                    }
                    else
                    {
                        message = "Invalid credential provided";
                    }
                }
                else
                {
                    message = "Invalid credential provided";
                }
            }
            ViewBag.Message = message;
            return View();
        }
        
        //Logout

        [Authorize]
        [HttpPost]
        public ActionResult Logout()
        {
            System.Web.HttpContext.Current.Session["Id"] = "0";
            System.Web.HttpContext.Current.Session["name"] = "";
            
            FormsAuthentication.SignOut();
            //Session.Clear();
            return RedirectToAction("Login", "User");
        }

        [NonAction]
        public bool IsEmailExist(string emailID)
        {
            using(DBModel con=new DBModel())
            {
                var x = con.Users.Where(a => a.EmailID == emailID).FirstOrDefault();
                return x != null;
            }
        }
    }
}