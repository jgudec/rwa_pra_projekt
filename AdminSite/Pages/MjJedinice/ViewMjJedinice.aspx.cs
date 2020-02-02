using DAL;
using DAL.Model;
using DAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminSite.Pages.MjJedinice
{
    public partial class ViewMjJedinice : System.Web.UI.Page
    {
        private List<MjJedinica> mjJedinice = SqlRepo.Instance.FetchMjJed();
        private List<Button> buttons = new List<Button>();
        private int IDMjJed;
        private MjJedinica mjJed;

        protected void Page_Load(object sender, EventArgs e)
        {
            BindDS();
        }

        private void BindDS()
        {
            listMjJed.Items.Clear();
            listMjJed.DataSource = mjJedinice;

            listMjJed.DataBind();
        }

        protected void lvMjJedinice_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {

        }

        protected void ddlSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            string meh = ddlSort.SelectedValue;
            switch (meh)
            {
                case "asc":
                    mjJedinice.Sort((x, y) => x.Naziv.CompareTo(y.Naziv));
                    BindDS();
                    break;

                default:
                    mjJedinice.Sort((x, y) => -x.Naziv.CompareTo(y.Naziv));
                    BindDS();
                    break;
            }
        }
    }
}