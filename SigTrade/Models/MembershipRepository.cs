using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using SigTrade.Interfaces;

namespace SigTrade.Models
{
    public class MembershipRepository : IMembershipRepository
    {
        public string[] getAllRoles()
        {

            return Roles.GetAllRoles();
        }

    }
}
