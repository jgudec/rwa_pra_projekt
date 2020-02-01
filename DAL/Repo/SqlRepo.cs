﻿using DAL.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class SqlRepo
    {
        private string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

        private static readonly Lazy<SqlRepo> lazy = new Lazy<SqlRepo>(() => new SqlRepo());
        public static SqlRepo Instance { get { return lazy.Value; } }

        

        //------------------------------Korisnici-----------------------------

        public bool ValidateAdmin(string username, string pwd)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "ValidateAdmin";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@user", SqlDbType.VarChar).Value = username;
                    cmd.Parameters.Add("@pass", SqlDbType.VarChar).Value = pwd;
                    object value = cmd.ExecuteScalar();
                    if ((int)value == 1) return true;
                    else return false;
                }
            }
        }

        public List<Korisnik> FetchKorisnici()
        {
            List<Korisnik> korisnici = new List<Korisnik>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "LoadKorisnici";
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                if (dr["KorisnickoIme"].ToString() != "admin")
                                {
                                    korisnici.Add(new Korisnik
                                    {
                                        IDKorisnik = (int)dr["IDKorisnik"],
                                        Ime = dr["Ime"].ToString(),
                                        Prezime = dr["Prezime"].ToString(),
                                        Spol = dr["Spol"].ToString()[0],
                                        FizickaAktivnost = (int)dr["FizickaAktivnost"],
                                        TipDijabetesa = (int)dr["TipDijabetesa"],
                                        Email = dr["Email"].ToString(),
                                        Visina = (int)dr["Visina"],
                                        Tezina = (int)dr["Tezina"],
                                        KorisnickoIme = dr["KorisnickoIme"].ToString(),
                                        DOB = DateTime.Parse(dr["DOB"].ToString()),
                                        BMI = (int)dr["BMI"]
                                    });
                                }
                            }
                        }
                    }
                }
            }
            return korisnici;
        }

        //---------------Obroci---------------------------------

        public List<Obrok> FetchObroci()
        {
            List<Obrok> obroci = new List<Obrok>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "LoadObroci";
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                obroci.Add(new Obrok
                                {
                                    IDObrok = (int)dr["IDObrok"],
                                    Naziv = dr["Naziv"].ToString(),
                                    Dostupan = (bool)dr["Dostupan"]
                                });
                            }
                        }
                    }
                }
            }
            return obroci;
        }

        public void ToggleObrok(int iDObrok, int stat)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "ToggleObrok";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@idObrok", SqlDbType.VarChar).Value = iDObrok;
                    cmd.Parameters.Add("@stat", SqlDbType.VarChar).Value = stat;
                    object value = cmd.ExecuteNonQuery();
                }
            }
        }

        public void InsertObrok(object text)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "InsertObrok";
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (text.ToString() != String.Empty)
                    {
                        cmd.Parameters.Add("@naz", SqlDbType.VarChar).Value = text;
                        object value = cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public void UpdateObrok(Obrok obrok)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    if (!FetchObroci().Contains(obrok))
                    {
                        cmd.CommandText = "UpdateObrok";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@naz", SqlDbType.VarChar).Value = obrok.Naziv;
                        cmd.Parameters.Add("@idobrok", SqlDbType.VarChar).Value = obrok.IDObrok;
                        object value = cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public void DeleteObrok(Obrok obrok)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    if (!FetchObroci().Contains(obrok))
                    {
                        try
                        {
                            cmd.CommandText = "DeleteObrok";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@idobrok", SqlDbType.VarChar).Value = obrok.IDObrok;
                            object value = cmd.ExecuteNonQuery();
                        }
                        catch (Exception)
                        {

                        }
                    }
                }
            }
        }
    }
}
