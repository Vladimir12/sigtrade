using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.UI;
using SignificantTradeSSRepository;
using SigTrade.Models;

namespace SigTrade.Controllers
{

    [HandleError]
    public class AccountController : Controller
    {

        // This constructor is used by the MVC framework to instantiate the controller using
        // the default forms authentication and membership providers.

        public AccountController()
            : this(null, null)
        {
        }

        // This constructor is not used by the MVC framework but is instead provided for ease
        // of unit testing this type. See the comments at the end of this file for more
        // information.
        public AccountController(IFormsAuthentication formsAuth, IMembershipService service)
        {
            FormsAuth = formsAuth ?? new FormsAuthenticationService();
            MembershipService = service ?? new AccountMembershipService();
        }

        public IFormsAuthentication FormsAuth
        {
            get;
            private set;
        }

        public IMembershipService MembershipService
        {
            get;
            private set;
        }

        public ActionResult LogOn()
        {
         
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings",
            Justification = "Needs to take same parameter type as Controller.Redirect()")]
        public ActionResult LogOn(string userName, string password, bool rememberMe, string returnUrl)
        {

            if (!ValidateLogOn(userName, password))
            {
                ViewData["rememberMe"] = rememberMe;
                return View();
            }
         
            FormsAuth.SignIn(userName, rememberMe);
            TempData["flash"] = "Welcome " + userName + ". You are logged in.";
            if (!String.IsNullOrEmpty(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Search", "SearchReview" );
            }
        }

        public ActionResult LogOff()
        {

            FormsAuth.SignOut();
            TempData["flash"] = "You have been logged out.";

            return RedirectToAction("Search", "SearchReview");
        }




        /// <summary>
        /// Outputs a list of all users on system. ADMIN ONLY
        /// </summary>
        [Authorize(Roles = UpdateUtils.ROLE_ADMINISTRATOR)]
        public ActionResult index()
        {
            ViewData["users"] = Membership.GetAllUsers();

            return View();
        }

        /// <summary>
        /// Show the details of a given user
        /// </summary>
        [Authorize(Roles = UpdateUtils.ROLE_ADMINISTRATOR)]
        public ActionResult show(string id)
        {
            MembershipUser sig_user = Membership.GetUser(new Guid(id));
            CountryRepository cr = new CountryRepository();

            ViewData["user"] = sig_user;
            ViewData["roles"] = Roles.GetRolesForUser(sig_user.UserName);
            ViewData["all_roles"] = Roles.GetAllRoles();
            ViewData["profile"] = Profile.GetProfile(sig_user.UserName);
            VwCountry country = new VwCountry();
            try
            {
                country = cr.getCountry(Profile.GetProfile(sig_user.UserName).country_id);
                ViewData["country"] = country.CtyShort;
            }catch
            {
                ViewData["country"] = "";
            }

            return View();
        }


        /// <summary>
        /// Registers a user on the system. Form Page. ADMIN ONLY
        /// </summary>
        [Authorize(Roles = UpdateUtils.ROLE_ADMINISTRATOR)]
        public ActionResult Register()
        {
            ViewData["PasswordLength"] = MembershipService.MinPasswordLength;
            ViewData["edit"] = false;
            addCountries();
            return View();
        }

    


        /// <summary>
        /// Edit page for a user on the system. Form Page. ADMIN ONLY
        /// </summary>
        [Authorize(Roles = UpdateUtils.ROLE_ADMINISTRATOR)]
        public ActionResult Edit(string id)
        {
            ViewData["edit"] = true;
            MembershipUser sig_user = Membership.GetUser(new Guid(id));
            ViewData["user"] = sig_user;

            //POPULATE BASIC INFO
            ViewData["username"] = sig_user.UserName;
            ViewData["email"] = sig_user.Email;
            ViewData["username"] = sig_user.UserName;

            //POPULATE PROFILE INFO
            Profile profile = Profile.GetProfile(sig_user.UserName);

            ViewData["first_name"] = profile.first_name;
            ViewData["last_name"] = profile.last_name;
            ViewData["organization"] = profile.organization;
            ViewData["address_1"] = profile.address_1;
            ViewData["address_2"] = profile.address_2;
            ViewData["address_3"] = profile.address_3;
            ViewData["town"] = profile.town;
            ViewData["state"] = profile.state;
            ViewData["postcode"] = profile.postcode;
            ViewData["telephone"] = profile.telephone;
            addCountries(profile.country_id);
            ViewData["PasswordLength"] = MembershipService.MinPasswordLength;
            return View();
        }

        /// <summary>
        /// Registers a user on the system. Actual guts. ADMIN ONLY
        /// </summary>
        [Authorize(Roles = UpdateUtils.ROLE_ADMINISTRATOR)]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(string userName,
                                      string email,
                                      string first_name,
                                      string last_name,
                                      string organization,
                                      string address_1,
                                      string address_2,
                                      string address_3,
                                      string town,
                                      string city,
                                      string state,
                                      string postcode,
                                      string country_id,
                                      string telephone)
        {

            ViewData["PasswordLength"] = MembershipService.MinPasswordLength;

            
                // Attempt to retrieve the user
                MembershipUser mu = Membership.GetUser(userName);

                //UPDATE BASICS
                mu.Email = email;
                Membership.UpdateUser(mu);
                
                //UPDATE PROFILE INFO
                Profile userProfile = Profile.GetProfile(userName);
                userProfile.first_name = first_name;
                userProfile.last_name = last_name;
                userProfile.organization = organization;
                userProfile.address_1 = address_1;
                userProfile.address_2 = address_2;
                userProfile.address_3 = address_3;
                userProfile.town = town;
                userProfile.state = state;
                userProfile.postcode = postcode;
                userProfile.country_id = int.Parse(country_id);
                userProfile.telephone = telephone;
                userProfile.Save();

               
                //return RedirectToAction("show", "account", mu.ProviderUserKey.ToString());
                TempData["flash"] = "User: " + userName + " updated.";
                return RedirectToAction("index");
                //return RedirectToAction(
                // new RouteValueDictionary(new {controller = "account", action = "show", id = mu.ProviderUserKey.ToString()}));
          
        }


         /// <summary>
        /// Deletes a user on the system. Actual guts. ADMIN ONLY
        /// </summary>
        [Authorize(Roles = UpdateUtils.ROLE_ADMINISTRATOR)]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete(string userName)
         {
             if (User.Identity.Name != userName)
             {
                 Membership.DeleteUser(userName);
                 TempData["flash"] = "User: " + userName + " deleted.";
             } else
             {
                 TempData["flash"] = "Unable to delete logged in user.";
             }
             return RedirectToAction("index");
         } 



        /// <summary>
        /// Registers a user on the system. Actual guts. ADMIN ONLY
        /// </summary>
        [Authorize(Roles = UpdateUtils.ROLE_ADMINISTRATOR)]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Register(string userName, 
                                      string email, 
                                      string password, 
                                      string confirmPassword,
                                      string first_name,
		                              string last_name,
		                              string organization,
                                      string address_1,
		                              string address_2,
		                              string address_3,
		                              string town,
		                              string city,
		                              string state,
		                              string postcode,
		                              string country_id,
		                              string telephone)
        {

            ViewData["PasswordLength"] = MembershipService.MinPasswordLength;

            if (ValidateRegistration(userName, email, password, confirmPassword))
            {
                // Attempt to register the user
                MembershipCreateStatus createStatus = MembershipService.CreateUser(userName, password, email);

                if (createStatus == MembershipCreateStatus.Success)
                {
                    //UPDATE PROFILE
                    Profile userProfile = Profile.GetProfile(userName);
                    userProfile.first_name = first_name;
                    userProfile.last_name = last_name;
                    userProfile.organization = organization;
                    userProfile.address_1 = address_1;
                    userProfile.address_2 = address_2;
                    userProfile.address_3 = address_3;
                    userProfile.town = town;
                    userProfile.state = state;
                    userProfile.postcode = postcode;
                   
                    //userProfile.country_id = int.Parse(country_id);
                    
                    userProfile.telephone = telephone;
                    userProfile.Save();

                    MembershipUser mu = Membership.GetUser(userName);

                    //return RedirectToAction("show", "account", mu.ProviderUserKey.ToString());
                    TempData["flash"] = "User: " + userName + " added.";
                    return RedirectToAction("index");
                    //return RedirectToAction(
                    // new RouteValueDictionary(new {controller = "account", action = "show", id = mu.ProviderUserKey.ToString()}));
                }
                else
                {
                    ModelState.AddModelError("_FORM", ErrorCodeToString(createStatus));
                }
            }

            // If we got this far, something failed, redisplay form
            addCountries();
            ViewData["edit"] = false;
            return View();
        }


        private void addCountries(int country_id)
        {
            CountryRepository cr = new CountryRepository();
            ViewData["countries"] = new SelectList(cr.getAll(), "CtyRecID", "CtyShort", country_id);      
      
        }

        private void addCountries()
        {
            CountryRepository cr = new CountryRepository();
            ViewData["countries"] = new SelectList( cr.getAll(), "CtyRecID", "CtyShort");

        }


        [Authorize]
        public ActionResult ChangePassword()
        {

            ViewData["PasswordLength"] = MembershipService.MinPasswordLength;

            return View();
        }

        [Authorize]
        [AcceptVerbs(HttpVerbs.Post)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes",
            Justification = "Exceptions result in password not being changed.")]
        public ActionResult ChangePassword(string currentPassword, string newPassword, string confirmPassword)
        {

            ViewData["PasswordLength"] = MembershipService.MinPasswordLength;

            if (!ValidateChangePassword(currentPassword, newPassword, confirmPassword))
            {
                return View();
            }

            try
            {
                if (MembershipService.ChangePassword(User.Identity.Name, currentPassword, newPassword))
                {
                    return RedirectToAction("ChangePasswordSuccess");
                }
                else
                {
                    ModelState.AddModelError("_FORM", "The current password is incorrect or the new password is invalid.");
                    return View();
                }
            }
            catch
            {
                ModelState.AddModelError("_FORM", "The current password is incorrect or the new password is invalid.");
                return View();
            }
        }

        public ActionResult ChangePasswordSuccess()
        {

            return View();
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ForgotPassword(string email)
        {
            string username = Membership.GetUserNameByEmail(email);
            if (username != null)
            {
                var user = Membership.GetUser(username);
                string newPassword = user.ResetPassword();
                UpdateUtils.SendPasswordResetNotification(user, newPassword);
            }
            return RedirectToAction("ResetPasswordSuccess");
        }

        public ActionResult ResetPasswordSuccess()
        {
            return View();
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity is WindowsIdentity)
            {
                throw new InvalidOperationException("Windows authentication is not supported.");
            }
        }

        #region Validation Methods

        private bool ValidateChangePassword(string currentPassword, string newPassword, string confirmPassword)
        {
            if (String.IsNullOrEmpty(currentPassword))
            {
                ModelState.AddModelError("currentPassword", "You must specify a current password.");
            }
            if (newPassword == null || newPassword.Length < MembershipService.MinPasswordLength)
            {
                ModelState.AddModelError("newPassword",
                    String.Format(CultureInfo.CurrentCulture,
                         "You must specify a new password of {0} or more characters.",
                         MembershipService.MinPasswordLength));
            }

            if (!String.Equals(newPassword, confirmPassword, StringComparison.Ordinal))
            {
                ModelState.AddModelError("_FORM", "The new password and confirmation password do not match.");
            }

            return ModelState.IsValid;
        }

        private bool ValidateLogOn(string userName, string password)
        {
            if (String.IsNullOrEmpty(userName))
            {
                ModelState.AddModelError("username", "You must specify a username.");
            }
            if (String.IsNullOrEmpty(password))
            {
                ModelState.AddModelError("password", "You must specify a password.");
            }
            if (!MembershipService.ValidateUser(userName, password))
            {
                ModelState.AddModelError("_FORM", "The username or password provided is incorrect.");
            }

            return ModelState.IsValid;
        }

        private bool ValidateRegistration(string userName, string email, string password, string confirmPassword)
        {
            if (String.IsNullOrEmpty(userName))
            {
                ModelState.AddModelError("username", "You must specify a username.");
            }
            //if (String.IsNullOrEmpty(email))
            //{
            //    ModelState.AddModelError("email", "You must specify an email address.");
            //}
            if (password == null || password.Length < MembershipService.MinPasswordLength)
            {
                ModelState.AddModelError("password",
                    String.Format(CultureInfo.CurrentCulture,
                         "You must specify a password of {0} or more characters.",
                         MembershipService.MinPasswordLength));
            }
            if (!String.Equals(password, confirmPassword, StringComparison.Ordinal))
            {
                ModelState.AddModelError("_FORM", "The new password and confirmation password do not match.");
            }
            return ModelState.IsValid;
        }

        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://msdn.microsoft.com/en-us/library/system.web.security.membershipcreatestatus.aspx for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "Username already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A username for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }
        #endregion
    }

    // The FormsAuthentication type is sealed and contains static members, so it is difficult to
    // unit test code that calls its members. The interface and helper class below demonstrate
    // how to create an abstract wrapper around such a type in order to make the AccountController
    // code unit testable.

    public interface IFormsAuthentication
    {
        void SignIn(string userName, bool createPersistentCookie);
        void SignOut();
    }

    public class FormsAuthenticationService : IFormsAuthentication
    {
        public void SignIn(string userName, bool createPersistentCookie)
        {
            FormsAuthentication.SetAuthCookie(userName, createPersistentCookie);
        }
        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }
    }

    public interface IMembershipService
    {
        int MinPasswordLength { get; }

        bool ValidateUser(string userName, string password);
        MembershipCreateStatus CreateUser(string userName, string password, string email);
        bool ChangePassword(string userName, string oldPassword, string newPassword);
    }

    public class AccountMembershipService : IMembershipService
    {
        private MembershipProvider _provider;

        public AccountMembershipService()
            : this(null)
        {
        }

        public AccountMembershipService(MembershipProvider provider)
        {
            _provider = provider ?? Membership.Provider;
            
        }

        public int MinPasswordLength
        {
            get
            {
                return _provider.MinRequiredPasswordLength;
            }
        }

        public bool ValidateUser(string userName, string password)
        {
            return _provider.ValidateUser(userName, password);
        }

        public MembershipCreateStatus CreateUser(string userName, string password, string email)
        {
            MembershipCreateStatus status;
            _provider.CreateUser(userName, password, email, null, null, true, null, out status);
            return status;
        }

        public void UpdateUser(MembershipUser user)
        {
            _provider.UpdateUser(user);
        }

     

        public bool ChangePassword(string userName, string oldPassword, string newPassword)
        {
            MembershipUser currentUser = _provider.GetUser(userName, true /* userIsOnline */);
            return currentUser.ChangePassword(oldPassword, newPassword);
        }
    }
}
