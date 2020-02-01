using DAL;
using DAL.Model;
using DAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminSite.Pages.Namirnice
{
    public partial class ViewNamirnice : System.Web.UI.Page
    {
        private List<Namirnica> namirnice = SqlRepo.Instance.FetchNamirnice();
        protected void Page_Load(object sender, EventArgs e)
        {
            BindDS();
        }

        private void BindDS()
        {
            listNamirnice.Items.Clear();
            listNamirnice.DataSource = namirnice;

            listNamirnice.DataBind();
        }
    }
}