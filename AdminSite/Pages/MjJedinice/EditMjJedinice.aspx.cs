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
    public partial class EditMjJedinice : System.Web.UI.Page
    {
        private List<MjJedinica> mjJedinice = SqlRepo.Instance.FetchMjJed();
        private List<Button> buttons = new List<Button>();
        private int IDMjJed;
        private MjJedinica mjJed;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillDdlMjJed();
            }

        }

        private void FillDdlMjJed()
        {
            ddlMjJed.DataSource = mjJedinice;
            ddlMjJed.DataTextField = "Naziv"; // Specify the name of the text field
            ddlMjJed.DataValueField = "IDMjernaJedinica"; // Specify the name of the value field
            ddlMjJed.DataBind();
            SetEdit();
        }

        private void SetEdit()
        {
            IDMjJed = int.Parse(ddlMjJed.SelectedValue);
            mjJed = mjJedinice.Find(x => x.IDMjernaJedinica == IDMjJed);
            tbNaziv.Text = mjJed.Naziv.ToString();
        }

        protected void ddlMjJed_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetEdit();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            SqlRepo.Instance.InsertMjJed(tbNaziv.Text);
            tbNaziv.Text = null;
            mjJedinice = SqlRepo.Instance.FetchMjJed();
            FillDdlMjJed();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                IDMjJed = int.Parse(ddlMjJed.SelectedValue);
                mjJed = mjJedinice.Find(x => x.IDMjernaJedinica == IDMjJed);
                mjJed.Naziv = tbNaziv.Text;
                SqlRepo.Instance.UpdateMjJed(mjJed);
                tbNaziv.Text = null;
                mjJedinice = SqlRepo.Instance.FetchMjJed();
                FillDdlMjJed();
            }
            catch (Exception){}
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                IDMjJed = int.Parse(ddlMjJed.SelectedValue);
                mjJed = mjJedinice.Find(x => x.IDMjernaJedinica == IDMjJed);
                SqlRepo.Instance.DeleteMjJed(mjJed);
                tbNaziv.Text = null;
                mjJedinice = SqlRepo.Instance.FetchMjJed();
                FillDdlMjJed();
            }
            catch (Exception) { }
        }
    }
}