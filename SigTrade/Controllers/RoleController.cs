using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Routing;
using System.Web.Security;
using SigTrade.Models;
using ArrayList=System.Collections.ArrayList;

namespace SigTrade.Controllers
{
    public class RoleController : Controller
    {
        //
        // GET: /Role/
        [Authorize(Roles = UpdateUtils.ROLE_ADMINISTRATOR)]
        public ActionResult Index()
        {
            ViewData["roles"] = Roles.GetAllRoles();
            return View();
        }

        //
        // GET: /Role/Details/5
        [Authorize(Roles = UpdateUtils.ROLE_ADMINISTRATOR)]
        public ActionResult Show(string id)
        {
            if (Roles.RoleExists(id))
            {
                ViewData["role"] = id;
                ViewData["users"] = Roles.GetUsersInRole(id);
                MembershipUserCollection mu = Membership.GetAllUsers();
                ViewData["all_users"] = new SelectList(mu, "UserName", "UserName");
                return View();
            } 
            
            return RedirectToAction("index");               
        }

       
        //
        // GET: /Role/Create
        [Authorize(Roles = UpdateUtils.ROLE_ADMINISTRATOR)]
        public ActionResult Create()
        {
            return View();
        } 

        
        // POST: /Role/add_user_to_role
        [Authorize(Roles = UpdateUtils.ROLE_ADMINISTRATOR)]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult add_user_to_role(string UserName, string role)
        {
            //ADD OTHER ROLES IF NEEDED
            string[] roles = {role};
            ArrayList roles_to_add = RoleLogic(new ArrayList(roles));

            //ATTACH ROLES TO USER
            AttachRoles(UserName, roles_to_add);

            //PREPARE DATA FOR SENDING BACK VIA AJAX
            ViewData["users"] = Roles.GetUsersInRole(role);
            ViewData["role"] = role;

            return PartialView("users_to_role_table");
        }

  
      
      // POST: /Role/update_roles_for_user
      [Authorize(Roles = UpdateUtils.ROLE_ADMINISTRATOR)]
      [AcceptVerbs(HttpVerbs.Post)]
      public ActionResult update_roles_for_user(string UserName, string[] new_roles)
      {
          try
          {           
              //PREPARE ALL THE ROLES IN THE SYSTEM
              ArrayList roles_to_delete = new ArrayList(Roles.GetAllRoles());

              //FIRST DELETE ALL ROLES FROM USER EXCEPT ADMINISTRATOR IF USER IS LOGGED IN
              if (User.Identity.Name == UserName)
              {
                  roles_to_delete.Remove(UpdateUtils.ROLE_ADMINISTRATOR);
              }

              //GET THE ROLES FOR THE CURRENT USER
              
              string[] roles_to_remove = Roles.GetRolesForUser(UserName);

              //REMOVE THE ROLES FOR THE CURRENT USER
              if (roles_to_remove.Count() > 0)
                Roles.RemoveUserFromRoles(UserName, roles_to_remove);

              //THEN REMOVE ALL ROLES FROM SELECTED USER. 
              //This is done freaky becasue the Role manage throws exceptions where user is not in a role and are trying to remove it
              //DetachRoles(UserName, roles_to_delete);

              //PREPARE NEW ROLES ENTERED
              ArrayList roles_to_add = RoleLogic(new ArrayList(new_roles));
              ArrayList roles_to_add_str2 = new ArrayList();
              foreach (var role in roles_to_add)
              {
                  if (!role.ToString().Equals("false"))
                      roles_to_add_str2.Add(role);
              }

              string[] roles_to_add_str = roles_to_add_str2.ToArray(typeof (string)) as string[];
              
              //ADDING THE ROLES TO THE USER
              Roles.AddUserToRoles(UserName,roles_to_add_str);

              //THEN ADD ROLES TO USER SPECIFIED. AGAIN FREAKY LIKE ABOVE.
              //AttachRoles(UserName,roles_to_add_str);

              //return Content(PrintValues((string[]) roles_to_add_stripped.ToArray(typeof (string))));

              //PREPARE DATA FOR SENDING BACK
              MembershipUser mu = Membership.GetUser(UserName);
              ViewData["user"] = mu;
              ViewData["roles"] = Roles.GetRolesForUser(UserName);
              ViewData["all_roles"] = Roles.GetAllRoles();
              TempData["flash"] = "Roles updated for " + UserName;

              return RedirectToAction("show", new {controller = "Account", id = mu.ProviderUserKey});
          }
          catch(Exception exception)
          {
              //IF THERE IS A MESS UP, RETURN ERROR TO FRONT
              TempData["flash"] = "Unable to update roles: " + exception.Message;
          }

        //OUTPUT BASIC FORM WITH NO CHANGES - MUST RELOAD INFORMATION
        MembershipUser mou = Membership.GetUser(UserName);
        ViewData["user"] = mou;
        ViewData["roles"] = Roles.GetRolesForUser(UserName);
        ViewData["all_roles"] = Roles.GetAllRoles();

        return RedirectToAction("show", new {controller = "Account", id = mou.ProviderUserKey});
      }


       //ATTACH ROLES FROM LIST TO USER
       private void AttachRoles(string UserName, ArrayList roles_to_add)
       {
           //THEN ADD ROLES TO USER SPECIFIED. AGAIN FREAKY LIKE ABOVE.
          foreach (string s in roles_to_add)
          {
            try
            {
                if (!s.Contains("false"))
                Roles.AddUserToRole(UserName, s);
            } 
            catch
            {
                //DO NOTHING - DUPLICATES WILL THROW ERRORS
            }    
          }
       }

        //DETACH ROLES FROM LIST TO USER
        private void DetachRoles(string UserName, ArrayList roles_to_delete)
        {
            foreach (string s in roles_to_delete)
            {
                try
                {
                    Roles.RemoveUserFromRole(UserName, s);
                }
                catch
                {
                    //DO NOTHING
                }
            }
        }




       //CREATES A ROLE LIST BASED ON ROLES SELECTED. NOTE: THERE WILL BE MANY DUPLICATES!
       private ArrayList RoleLogic(ArrayList roles_to_add)
       {
           //IF ADMINISTRATOR, GRANT ALL ROLES
           if (roles_to_add.Contains(UpdateUtils.ROLE_ADMINISTRATOR))
           {
               return new ArrayList(Roles.GetAllRoles());
           }

           //IF DATA MANAGER, ALSO MUST BE A CONTIBUTOR
           if (roles_to_add.Contains(UpdateUtils.ROLE_DATA_MANAGER))
           {
               if (!roles_to_add.Contains(UpdateUtils.ROLE_DATA_CONTRIBUTOR))
               roles_to_add.Add(UpdateUtils.ROLE_DATA_CONTRIBUTOR);
           }

           //IF DATA CONTRIBUTOR, THEN DON'T NEED TO ADD ANYTHIMG

           //IF FULL VIEWER, THEY MUST BE INTERMEDIATE AND PUBLIC
           if (roles_to_add.Contains(UpdateUtils.ROLE_FULL_VIEWER))
           {
              if (!roles_to_add.Contains(UpdateUtils.ROLE_INTERMEDIATE_VIEWER))
               roles_to_add.Add(UpdateUtils.ROLE_INTERMEDIATE_VIEWER);
              if (!roles_to_add.Contains(UpdateUtils.ROLE_PUBLIC_VIEWER))
               roles_to_add.Add(UpdateUtils.ROLE_PUBLIC_VIEWER);
           }

           //IF INTERMEDIATE, MUST BE PUBLIC
           if (roles_to_add.Contains(UpdateUtils.ROLE_INTERMEDIATE_VIEWER))
           {
               if (!roles_to_add.Contains(UpdateUtils.ROLE_PUBLIC_VIEWER))
               roles_to_add.Add(UpdateUtils.ROLE_PUBLIC_VIEWER);
           }

           //RETURN FULL LIST 
           return roles_to_add;

       }



      public  string PrintValues(IEnumerable myList)
      {
          String value_to_return = "";
          foreach (String obj in myList)
              value_to_return = value_to_return + "<br>" + obj;

          return value_to_return;
      }

        // POST: /Role/remove_user_from_role
      [Authorize(Roles = UpdateUtils.ROLE_ADMINISTRATOR)]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult remove_user_from_role(string UserName, string role)
        {
            try
            {
                // TODO: Add insert logic here
                if (Roles.RoleExists(role))
                {    
                    Roles.RemoveUserFromRole(UserName, role);

                    //PREPARE DATA FOR SENDING BACK VIA AJAX
                    ViewData["users"] = Roles.GetUsersInRole(role);
                    ViewData["role"] = role;
                    return PartialView("users_to_role_table");
                }
               
            }
            catch
            {
                
            }
            //OUTPUT BASIC FORM WITH NO CHANGES - MUST RELOAD INFORMATION
            ViewData["users"] = Roles.GetUsersInRole(role);
            ViewData["role"] = role;
            return PartialView("users_to_role_table");
        }

        //
        // GET: /Role/Edit/5
        [Authorize(Roles = UpdateUtils.ROLE_ADMINISTRATOR)]
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Role/Edit/5
        [Authorize(Roles = UpdateUtils.ROLE_ADMINISTRATOR)]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
