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
    public partial class EditObroci : System.Web.UI.Page
    {
        private List<Obrok> obroci = SqlRepo.Instance.FetchObroci();
        private int IDObrok;
        private Obrok obrok;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillDdlObroci();
            }
        }

        private void FillDdlObroci()
        {
            ddlObroci.DataSource = obroci;
            ddlObroci.DataTextField = "Naziv"; // Specify the name of the text field
            ddlObroci.DataValueField = "IDObrok"; // Specify the name of the value field
            ddlObroci.DataBind();
            SetEdit();
        }

        private void SetEdit()
        {
            IDObrok = int.Parse(ddlObroci.SelectedValue);
            obrok = obroci.Find(x => x.IDObrok == IDObrok);
            tbNaziv.Text = obrok.Naziv.ToString();
        }

        protected void ddlObroci_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetEdit();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            SqlRepo.Instance.InsertObrok(tbNaziv.Text);
            tbNaziv.Text = null;
            obroci = SqlRepo.Instance.FetchObroci();
            FillDdlObroci();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                IDObrok = int.Parse(ddlObroci.SelectedValue);
                obrok = obroci.Find(x => x.IDObrok == IDObrok);
                SqlRepo.Instance.DeleteObrok(obrok);
                tbNaziv.Text = null;
                obroci = SqlRepo.Instance.FetchObroci();
                FillDdlObroci();
            }
            catch (Exception) { }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                IDObrok = int.Parse(ddlObroci.SelectedValue);
                obrok = obroci.Find(x => x.IDObrok == IDObrok);
                obrok.Naziv = tbNaziv.Text;
                SqlRepo.Instance.UpdateObrok(obrok);
                tbNaziv.Text = null;
                obroci = SqlRepo.Instance.FetchObroci();
                FillDdlObroci();
            }
            catch (Exception) { }
        }
    }
}