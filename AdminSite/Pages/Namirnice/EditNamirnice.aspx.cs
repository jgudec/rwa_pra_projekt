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
    public partial class EditNamirnice : System.Web.UI.Page
    {
        private List<Namirnica> namirnice = SqlRepo.Instance.FetchNamirnice();
        private List<TipNamirnice> tipoviNamirnica = SqlRepo.Instance.FetchTipoviNamirnica();
        private List<Button> buttons = new List<Button>();
        private int IDNamirnica;
        private Namirnica namirnica;
        private TipNamirnice tipNamirnice = new TipNamirnice();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillDdlNamirnice();
                FillDdlTipoviNamirnica();
            }

        }

        private void FillDdlTipoviNamirnica()
        {
            ddlTipoviNamirnica.DataSource = tipoviNamirnica;
            ddlTipoviNamirnica.DataTextField = "Naziv"; // Specify the name of the text field
            ddlTipoviNamirnica.DataValueField = "IDTipNamirnice"; // Specify the name of the value field
            ddlTipoviNamirnica.DataBind();

        }

        private void FillDdlNamirnice()
        {
            ddlNamirnice.DataSource = namirnice;
            ddlNamirnice.DataTextField = "Naziv"; // Specify the name of the text field
            ddlNamirnice.DataValueField = "IDNamirnica"; // Specify the name of the value field
            ddlNamirnice.DataBind();
            SetEdit();
        }

        private void SetEdit()
        {
            IDNamirnica = int.Parse(ddlNamirnice.SelectedValue);
            namirnica = namirnice.Find(x => x.IDNamirnica == IDNamirnica);
            tbNaziv.Text = namirnica.Naziv.ToString();
            tbKcal.Text = namirnica.Kcal.ToString();
            tbKj.Text = namirnica.Kj.ToString();
            ddlTipoviNamirnica.SelectedValue = tipoviNamirnica.Find(x => x.Naziv == namirnica.tipNamirnice).IDTipNamirnice.ToString();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Namirnica x = new Namirnica();
            x.Naziv = tbNaziv.Text.ToString();
            x.Kj = int.Parse(tbKj.Text.ToString());
            x.Kcal = int.Parse(tbKcal.Text.ToString());
            x.tipNamirnice = ddlTipoviNamirnica.SelectedValue.ToString();
            SqlRepo.Instance.InsertNamirnica(x);
            tbNaziv.Text = null;
            tbKj.Text = null;
            tbKcal.Text = null;
            namirnice = SqlRepo.Instance.FetchNamirnice();
            FillDdlNamirnice();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                IDNamirnica = int.Parse(ddlNamirnice.SelectedValue);
                namirnica = namirnice.Find(x => x.IDNamirnica == IDNamirnica);
                SqlRepo.Instance.DeleteNamirnica(namirnica);
                tbNaziv.Text = null;
                tbKj.Text = null;
                tbKcal.Text = null;
                namirnice = SqlRepo.Instance.FetchNamirnice();
                FillDdlNamirnice();
            }
            catch (Exception) { }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            tipNamirnice = SqlRepo.Instance.GetTipNamirnice();
            try
            {
                IDNamirnica = int.Parse(ddlNamirnice.SelectedValue);
                namirnica = namirnice.Find(x => x.IDNamirnica == IDNamirnica);
                namirnica.Naziv = tbNaziv.Text;
                namirnica.Kcal = int.Parse(tbKcal.Text);
                namirnica.Kj = int.Parse(tbKj.Text);
                namirnica.tipNamirnice = tipNamirnice.Naziv;
                SqlRepo.Instance.UpdateNamirnica(namirnica);
                tbNaziv.Text = null;
                tbKj.Text = null;
                tbKcal.Text = null;
                namirnice = SqlRepo.Instance.FetchNamirnice();
                FillDdlNamirnice();
            }
            catch (Exception) { }
        }

        protected void ddlNamirnice_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetEdit();
        }

        protected void ddlTipoviNamirnica_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            DropDownList mueh = (DropDownList)sender;
            tipNamirnice.IDTipNamirnice = mueh.SelectedIndex+1;
            tipNamirnice.Naziv = tipoviNamirnica.Find(x => x.IDTipNamirnice == tipNamirnice.IDTipNamirnice).Naziv;
            SqlRepo.Instance.SetTipNamirnice(tipNamirnice);
        }
    }
}