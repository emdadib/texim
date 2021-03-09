using texim.Data;
using texim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Identity;
using texim.Data.IDAL;

namespace texim.Data.Services
{
    public class UserService
    {
        private static  AspNetUserManager _userManager;
        private static  IUnitOfWork unitOfWork;

        public UserService()
        {
        }

        public UserService(ApplicationUserManager userManager,  IUnitOfWork _unitOfWork)
        {
            UserManager = userManager;
            unitOfWork = _unitOfWork;
        }

      
        public static ApplicationUserManager UserManager
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

        public static List<IdentityUser> GetUsers()
        {
            return new ApplicationDbContext().Users.ToList();
        }

        public static IdentityUser GetUser(string userId)
        {
            return new ApplicationDbContext().Users.Find(userId);
        }

        public static string GetUserRole(string userid)
        {
            return UserManager.GetRoles(userid).FirstOrDefault() ?? "";
        }

        public static void UpdateUserRole(string userId, string roleId)
        {
            UserManager.RemoveFromRoles(userId);
            UserManager.AddToRole(userId, roleId);
        }
    }
}