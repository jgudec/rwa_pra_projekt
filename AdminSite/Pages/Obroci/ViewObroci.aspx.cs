using DAL;
using DAL.Model;
using DAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminSite.Pages.Obroci
{
    public partial class ViewObroci : System.Web.UI.Page
    {
        private List<Obrok> obroci = SqlRepo.Instance.FetchObroci();
        private List<Obrok> nedostupniObroci = SqlRepo.Instance.FetchObroci();

        protected void Page_Load(object sender, EventArgs e)
        {
            BindDS();

        }

        private void BindDS()
        {
            lvObroci.Items.Clear();
            obroci = obroci.Distinct().ToList();
            lvObroci.DataSource = obroci;

            nedostupniObroci = obroci.Where(x => x.Dostupan == false).ToList();

            lvObroci.DataBind();
        }

        protected void lvObroci_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            dpObrok.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            BindDS();
        }

        protected void btnToggle_Click(object sender, EventArgs e)
        {
            var meh = sender as Button;
            int IDObrok = int.Parse((sender as Button).CommandArgument);
            int stat;
            if (meh.Text != "X")
            {
                stat = 1;
            }
            else
            {
                stat = 0;
            }
            SqlRepo.Instance.ToggleObrok(IDObrok, stat);
            BindDS();
        }

        protected void btnToggle_PreRender(object sender, EventArgs e)
        {
            var btnToggle = sender as Button;

            if (nedostupniObroci.Where(x => x.IDObrok.ToString() == btnToggle.CommandArgument).Count() > 0)
            {
                btnToggle.CssClass = "waves-effect waves-light btn-small green padding";
                btnToggle.Text = "+";
            }
            else
            {
                btnToggle.CssClass = "waves-effect waves-light btn-small red padding";
                btnToggle.Text = "X";
            }
        }

        protected void ddlSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            string meh = ddlSort.SelectedValue;
            switch (meh)
            {
                case "asc":
                    obroci.Sort((x, y) => x.Naziv.CompareTo(y.Naziv));
                    BindDS();
                    break;

                default:
                    obroci.Sort((x, y) => -x.Naziv.CompareTo(y.Naziv));
                    BindDS();
                    break;
            }
        }
    }
}