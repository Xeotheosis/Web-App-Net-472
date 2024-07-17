using BussinesLogic.Services;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppNet472
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                string username = HttpContext.Current.User.Identity.Name;
                string role = GetUserRole(username);

                lblUserInfo.Text = $"Logged in as: {username} (Role: {role})";
            }
        }

        private string GetUserRole(string username)
        {
            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["AsPropManagerDb"].ConnectionString;
            var userRepository = new UserRepository();
            var userService = new UserService(userRepository);
            var user =  userService.GetUserByUsername(username);
            return user?.Role ?? "No Role";
        }
    }

}