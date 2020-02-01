using DAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminSite
{
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoginCard.Focus();
        }

        protected void LoginCard_Authenticate(object sender, AuthenticateEventArgs e)
        {
            bool authenticated = false;
            authenticated = SqlRepo.Instance.ValidateAdmin(LoginCard.UserName, LoginCard.Password);

            e.Authenticated = authenticated;
        }
    }
}