using DAL;
using DAL.Model;
using DAL.Repo;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace AdminSite.Pages.Korisnici
{
    public partial class ViewKorisnici : System.Web.UI.Page
    {
        private List<Korisnik> korisnici = SqlRepo.Instance.FetchKorisnici();
        private string xlsxPath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory) + @"\Korisnici.xlsx";
        private List<Button> buttons = new List<Button>();
        private List<Korisnik> selectedKorisnici = new List<Korisnik>();
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadDB();
        }

        private void LoadDB()
        {
            foreach (Korisnik user in korisnici)
            {
                HtmlTableRow tr = new HtmlTableRow();
                //gumb
                var td = new HtmlTableCell();
                Button btnSelect = new Button();
                btnSelect.CssClass = "waves-effect waves-light btn-small blue";
                btnSelect.Text = "Select";
                btnSelect.ID = user.IDKorisnik.ToString();
                btnSelect.Click += new EventHandler(btnSelect_Click);
                td.Controls.Add(btnSelect);
                tr.Controls.Add(td);
                buttons.Add(btnSelect);
                //Korisnicko Ime
                var td1 = new HtmlTableCell();
                td1.InnerText = user.KorisnickoIme;
                tr.Controls.Add(td1);
                //Ime
                var td11 = new HtmlTableCell();
                td11.InnerText = user.Ime;
                tr.Controls.Add(td11);
                //Prezime
                var td2 = new HtmlTableCell();
                td2.InnerText = user.Prezime;
                tr.Controls.Add(td2);
                //Email
                var td3 = new HtmlTableCell();
                td3.InnerText = user.Email;
                tr.Controls.Add(td3);
                //Datum Rođenja
                var td4 = new HtmlTableCell();
                td4.InnerText = user.DOB.ToLongDateString();
                tr.Controls.Add(td4);
                //Spol
                var td5 = new HtmlTableCell();
                td5.InnerText = user.Spol.ToString();
                tr.Controls.Add(td5);
                //Tip Dijabetesa
                var td6 = new HtmlTableCell();
                td6.InnerText = user.TipDijabetesa.ToString();
                tr.Controls.Add(td6);
                //Razina Fizicke Aktivnosti
                var td7 = new HtmlTableCell();
                td7.InnerText = user.FizickaAktivnost.ToString();
                tr.Controls.Add(td7);
                //Tezina
                var td8 = new HtmlTableCell();
                td8.InnerText = user.Tezina.ToString();
                tr.Controls.Add(td8);
                //Visina
                var td9 = new HtmlTableCell();
                td9.InnerText = user.Visina.ToString();
                tr.Controls.Add(td9);
                //BMI
                var td10 = new HtmlTableCell();
                td10.InnerText = user.BMI.ToString();
                tr.Controls.Add(td10);

                tableBody.Controls.Add(tr);
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            Button meh = sender as Button;
            foreach (Button btn in buttons)
            {
                if (meh.ID == btn.ID)
                {
                    btn.Text = "Selected";
                    btn.Enabled = false;
                    foreach (Korisnik k in korisnici)
                    {
                        if (btn.ID == k.IDKorisnik.ToString())
                        {
                            selectedKorisnici.Add(k);
                        }
                    }
                }
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            foreach (Button btn in buttons)
            {
                btn.Text = "Select";
                btn.Enabled = true;
                selectedKorisnici.Clear();
            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            List<Korisnik> korExport = new List<Korisnik>();
            bool empty = true;
            foreach (Button btn in buttons)
            {
                if (btn.Text == "Selected")
                {
                    empty = false;
                    korExport.AddRange(korisnici.Where(x => btn.ID == x.IDKorisnik.ToString()));
                }
            }
            if (empty)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('I can export nothing, but that's probably not what you want.');", true);
            }
            ExportKorisnici(korExport);
        }

        private void ExportKorisnici(List<Korisnik> korExport)
        {
            XSSFWorkbook wb = new XSSFWorkbook();
            ISheet sheet = wb.CreateSheet("Korisnici");
            for (int i = 0; i < korExport.Count; i++)
            {
                IRow row = sheet.CreateRow(i);
                row.CreateCell(0).SetCellValue(korExport[i].KorisnickoIme);
                row.CreateCell(1).SetCellValue(korExport[i].Ime);
                row.CreateCell(2).SetCellValue(korExport[i].Prezime);
                row.CreateCell(3).SetCellValue(korExport[i].Email);
                row.CreateCell(4).SetCellValue(korExport[i].DOB);
                row.CreateCell(5).SetCellValue(korExport[i].Spol);
                row.CreateCell(6).SetCellValue(korExport[i].TipDijabetesa);
                row.CreateCell(7).SetCellValue(korExport[i].FizickaAktivnost);
                row.CreateCell(8).SetCellValue(korExport[i].Tezina);
                row.CreateCell(9).SetCellValue(korExport[i].Visina);
                row.CreateCell(10).SetCellValue(korExport[i].BMI);
            }

            using (FileStream fileOut = new FileStream(xlsxPath, FileMode.OpenOrCreate, FileAccess.Write))  wb.Write(fileOut);  

            FileInfo file = new FileInfo(xlsxPath);
            // Download.
            if (file.Exists)
            {
                Response.ContentType = "application/vnd.ms-excel";
                Response.AppendHeader("Content-Disposition", "Attachment; Filename=" + file.Name + "");
                Response.TransmitFile(xlsxPath);
                Response.End();
            }
        }
    }
}