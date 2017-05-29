using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Web.Script.Serialization;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace Transformers
{
    public partial class Default : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\rnegrych\documents\visual studio 2015\Projects\Transformers\Transformers\App_Data\Database1.mdf;Integrated Security = True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Build the GridView1 table
                DefaultDatabase1Record();
            }
            else
            {
                //Do something
            }
        }

        //**************************************************************************************
        //*
        //**************************************************************************************
        public void DefaultDatabase1Record()
        {

            SqlCommand cmd = new SqlCommand("select * from Transformers", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            da.Fill(ds);
            int count = ds.Tables[0].Rows.Count;
            if (ds.Tables[0].Rows.Count > 0)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            else
            {
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                GridView1.DataSource = ds;
                GridView1.DataBind();
                int columncount = GridView1.Rows[0].Cells.Count;
                lblmsg.Text = " No data found !!!";
            }
        }
                
        //**************************************************************************************
        //*
        //**************************************************************************************
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName.Equals("AddNew"))
            {

                TextBox i_id = (TextBox)GridView1.FooterRow.FindControl("i_id");
                TextBox i_name = (TextBox)GridView1.FooterRow.FindControl("i_name");

                DropDownList i_AutobotDecepticon = (DropDownList)GridView1.FooterRow.FindControl("i_AutobotDecepticon");
                DropDownList i_strength = (DropDownList)GridView1.FooterRow.FindControl("i_strength");
                DropDownList i_intelligence = (DropDownList)GridView1.FooterRow.FindControl("i_intelligence");
                DropDownList i_speed = (DropDownList)GridView1.FooterRow.FindControl("i_speed");
                DropDownList i_endurance = (DropDownList)GridView1.FooterRow.FindControl("i_endurance");
                DropDownList i_rank = (DropDownList)GridView1.FooterRow.FindControl("i_rank");
                DropDownList i_courage = (DropDownList)GridView1.FooterRow.FindControl("i_courage");
                DropDownList i_firepower = (DropDownList)GridView1.FooterRow.FindControl("i_firepower");
                DropDownList i_skill = (DropDownList)GridView1.FooterRow.FindControl("i_skill");
                DropDownList i_overallRating = (DropDownList)GridView1.FooterRow.FindControl("overallRating");

                //Here is where we calculate the Transformer's Overall Rating
                int overallRating;
                overallRating = Int32.Parse(i_strength.Text) + Int32.Parse(i_intelligence.Text) + Int32.Parse(i_speed.Text) + Int32.Parse(i_endurance.Text) + Int32.Parse(i_firepower.Text);
                con.Open();

                SqlCommand cmd = new SqlCommand("insert into Transformers(name,AutobotDecepticon, strength, intelligence, speed,endurance, rank, courage, firepower, skill, overallRating) values('" + i_name.Text + "','" + i_AutobotDecepticon.Text + "','" + Int32.Parse(i_strength.Text) + "','" + Int32.Parse(i_intelligence.Text) + "','" + Int32.Parse(i_speed.Text) + "','" + Int32.Parse(i_endurance.Text) + "','" + Int32.Parse(i_rank.Text) + "','" + Int32.Parse(i_courage.Text) + "','" + Int32.Parse(i_firepower.Text) + "','" + Int32.Parse(i_skill.Text) + "','" + overallRating + "')", con);

                int result = cmd.ExecuteNonQuery();
                con.Close();
                if (result == 1)
                {
                    DefaultDatabase1Record();
                    lblmsg.BackColor = Color.Green;
                    lblmsg.ForeColor = Color.White;
                    lblmsg.Text = "      Transformer added successfully......    ";
                }
                else
                {
                    lblmsg.BackColor = Color.Red;
                    lblmsg.ForeColor = Color.White;
                    lblmsg.Text = i_id.Text + " Error while adding row.....";
                }
            }
        }

        //**************************************************************************************
        //*
        //**************************************************************************************
        protected void btn_StartBattle_Click(object sender, EventArgs e)
        {
            StartBattle();
        }

        //**************************************************************************************
        //*
        //**************************************************************************************
        public void StartBattle() {

            //**************************************************************************************
            //Get Team Transformers
            //**************************************************************************************
            SqlCommand cmd1 = new SqlCommand("select * from Transformers where AutobotDecepticon = 'A' order by overallRating desc", con);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);

            DataSet ds_Autobots = new DataSet();
            da1.Fill(ds_Autobots);

            //**************************************************************************************
            //Get Team Decepticons
            //**************************************************************************************
            SqlCommand cmd2 = new SqlCommand("select * from Transformers where AutobotDecepticon = 'D' order by overallRating desc", con);
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);

            DataSet ds_Decepticons = new DataSet();
            da2.Fill(ds_Decepticons);

            //**************************************************************************************
            //Calculate Number of battles
            //**************************************************************************************
            int numbattles = 0;
            int numberbattles = 0;
            int number_battles = 0;
            bool specialRule = false;

            //**************************************************************************************
            //* Additional variables  have been created in the event that the games is expended upon
            //**************************************************************************************
            int numberOfWinsAutobots = 0;
            int numberOfLosesAutobots = 0;
            int numberOfTiesAutobots = 0;
            int numberOfWinsDecepticons = 0;
            int numberOfLosesDecepticons = 0;
            int numberOfTiesDecepticons = 0;

            List<string> winningTeamAutobots = new List<string>();            
            List<string> DecepticonsSurvivors = new List<string>();
            List<string> winningTeamDecepticons = new List<string>();
            List<string> AutobotsSurvivors = new List<string>();
            List<string> losingTeamsAutobots = new List<string>();
            List<string> losingTeamsDecepticons = new List<string>();
            List<string> DestroyedTransformers = new List<string>();

            //**************************************************************************************
            //* Game (Battle) Logic
            //**************************************************************************************
            if ((ds_Autobots.Tables[0].Rows.Count > 0) && (ds_Decepticons.Tables[0].Rows.Count > 0)) {
                //Equal number of rows

                if ((ds_Autobots.Tables[0].Rows.Count == 1) && (ds_Decepticons.Tables[0].Rows.Count == 1))
                {
                    numbattles = 1;
                    numberbattles = 1;
                    number_battles = 1;

                }
                else if ((ds_Autobots.Tables[0].Rows.Count > ds_Decepticons.Tables[0].Rows.Count))
                {
                    numbattles = (ds_Decepticons.Tables[0].Rows.Count);
                    numberbattles = numbattles;
                    number_battles = numbattles;

                    //AutobotSurvivors
                    for (int j = numbattles; j <= ds_Autobots.Tables[0].Rows.Count - 1; j++) {
                        AutobotsSurvivors.Add(ds_Autobots.Tables[0].Rows[j][1].ToString());
                    }

                }
                else if ((ds_Decepticons.Tables[0].Rows.Count > ds_Autobots.Tables[0].Rows.Count))
                {
                    numbattles = (ds_Autobots.Tables[0].Rows.Count);
                    numberbattles = numbattles;
                    number_battles = numbattles;

                    //DecepticonSurvivors
                    for (int j = numbattles; j <= ds_Decepticons.Tables[0].Rows.Count - 1; j++)
                    {
                        DecepticonsSurvivors.Add(ds_Decepticons.Tables[0].Rows[j][1].ToString());
                    }

                }
                else if ((ds_Decepticons.Tables[0].Rows.Count == ds_Autobots.Tables[0].Rows.Count))
                {
                    numbattles = (ds_Autobots.Tables[0].Rows.Count);
                    numberbattles = numbattles;
                }
            }

            for (int i = 0; i <= numbattles - 1; i++)
            {
                //**************************************************************************************
                //* Check for Special Battle Rules
                //**************************************************************************************
                if (ds_Autobots.Tables[0].Rows[i][1].ToString() == "Optimus Prime" && ds_Decepticons.Tables[0].Rows[i][1].ToString() != "Predaking")
                {
                    numberOfWinsAutobots = numberOfWinsAutobots + 1;
                    numberOfLosesDecepticons = numberOfLosesDecepticons + 1;
                    numberOfTiesAutobots = numberOfTiesAutobots + 0;
                    numberOfTiesDecepticons = numberOfTiesDecepticons + 0;

                    winningTeamAutobots.Add(ds_Autobots.Tables[0].Rows[i][1].ToString());
                    losingTeamsDecepticons.Add(ds_Decepticons.Tables[0].Rows[i][1].ToString());

                }
                else if ((ds_Autobots.Tables[0].Rows[i][1].ToString() != "Optimus Prime") && (ds_Decepticons.Tables[0].Rows[i][1].ToString() == "Predaking"))
                {
                    numberOfWinsDecepticons = numberOfWinsDecepticons + 1;
                    numberOfLosesAutobots = numberOfLosesAutobots + 1;
                    numberOfTiesAutobots = numberOfTiesAutobots + 0;
                    numberOfTiesDecepticons = numberOfTiesDecepticons + 0;

                    winningTeamDecepticons.Add(ds_Decepticons.Tables[0].Rows[i][1].ToString());
                    losingTeamsAutobots.Add(ds_Autobots.Tables[0].Rows[i][1].ToString());

                }
                else if (((ds_Autobots.Tables[0].Rows[i][1].ToString() == "Optimus Prime") && (ds_Decepticons.Tables[0].Rows[i][1].ToString() == "Predaking")) || ((ds_Autobots.Tables[0].Rows[i][1].ToString() == "Optimus Prime") && (ds_Decepticons.Tables[0].Rows[i][1].ToString() == "Optimus Prime")) || ((ds_Autobots.Tables[0].Rows[i][1].ToString() == "Predaking") && (ds_Decepticons.Tables[0].Rows[i][1].ToString() == "Predaking"))) {
                    //**************************************************************************************
                    //* The game immediately ends with all competitors destroyed
                    //**************************************************************************************
                    specialRule = true;
                    break;

                    //**************************************************************************************
                    //* Check for basic Rules of Battle
                    //**************************************************************************************                   
                }//CourageA - CourageD >=4 and StrengthA - StrengthD >=3
                else if ((Int32.Parse(ds_Autobots.Tables[0].Rows[i][8].ToString()) - Int32.Parse(ds_Decepticons.Tables[0].Rows[i][8].ToString()) >= 4) && (Int32.Parse(ds_Autobots.Tables[0].Rows[i][3].ToString()) - Int32.Parse(ds_Decepticons.Tables[0].Rows[i][3].ToString()) >= 3)) {
                    numberOfWinsAutobots = numberOfWinsAutobots + 1;
                    numberOfLosesDecepticons = numberOfLosesDecepticons + 1;
                    numberOfTiesAutobots = numberOfTiesAutobots + 0;
                    numberOfTiesDecepticons = numberOfTiesDecepticons + 0;

                    winningTeamAutobots.Add(ds_Autobots.Tables[0].Rows[i][1].ToString());
                    losingTeamsDecepticons.Add(ds_Decepticons.Tables[0].Rows[i][1].ToString());

                }//CourageD - CourageA >=4 and StrengthD - StrengthA >=3
                else if ((Int32.Parse(ds_Decepticons.Tables[0].Rows[i][8].ToString()) - Int32.Parse(ds_Autobots.Tables[0].Rows[i][8].ToString()) >= 4) && (Int32.Parse(ds_Decepticons.Tables[0].Rows[i][3].ToString()) - Int32.Parse(ds_Autobots.Tables[0].Rows[i][3].ToString()) >= 3)) {
                    numberOfWinsDecepticons = numberOfWinsDecepticons + 1;
                    numberOfLosesAutobots = numberOfLosesAutobots + 1;
                    numberOfTiesDecepticons = numberOfTiesDecepticons + 0;

                    winningTeamDecepticons.Add(ds_Decepticons.Tables[0].Rows[i][1].ToString());
                    losingTeamsAutobots.Add(ds_Autobots.Tables[0].Rows[i][1].ToString());

                }//SkillA - SkillD > 3
                else if (Int32.Parse(ds_Autobots.Tables[0].Rows[i][10].ToString()) - Int32.Parse(ds_Decepticons.Tables[0].Rows[i][10].ToString()) >= 3)
                {
                    numberOfWinsAutobots = numberOfWinsAutobots + 1;
                    numberOfLosesDecepticons = numberOfLosesDecepticons + 1;
                    numberOfTiesAutobots = numberOfTiesAutobots + 0;
                    numberOfTiesDecepticons = numberOfTiesDecepticons + 0;

                    winningTeamAutobots.Add(ds_Autobots.Tables[0].Rows[i][1].ToString());
                    losingTeamsDecepticons.Add(ds_Decepticons.Tables[0].Rows[i][1].ToString());


                }//SkillD - SkillA > 3
                else if (Int32.Parse(ds_Decepticons.Tables[0].Rows[i][10].ToString()) - Int32.Parse(ds_Autobots.Tables[0].Rows[i][10].ToString()) >= 3)
                {
                    numberOfWinsDecepticons = numberOfWinsDecepticons + 1;
                    numberOfLosesAutobots = numberOfLosesAutobots + 1;
                    numberOfTiesAutobots = numberOfTiesAutobots + 0;
                    numberOfTiesDecepticons = numberOfTiesDecepticons + 0;

                    winningTeamDecepticons.Add(ds_Decepticons.Tables[0].Rows[i][1].ToString());
                    losingTeamsAutobots.Add(ds_Autobots.Tables[0].Rows[i][1].ToString());

                }//OverallRatingA > OverallRatingD
                else if (Int32.Parse(ds_Autobots.Tables[0].Rows[i][11].ToString()) > Int32.Parse(ds_Decepticons.Tables[0].Rows[i][11].ToString()))
                {
                    numberOfWinsAutobots = numberOfWinsAutobots + 1;
                    numberOfLosesDecepticons = numberOfLosesDecepticons + 1;
                    numberOfTiesAutobots = numberOfTiesAutobots + 0;
                    numberOfTiesDecepticons = numberOfTiesDecepticons + 0;

                    winningTeamAutobots.Add(ds_Autobots.Tables[0].Rows[i][1].ToString());
                    losingTeamsDecepticons.Add(ds_Decepticons.Tables[0].Rows[i][1].ToString());


                }//OverallRatingD > OverallRatingA
                else if (Int32.Parse(ds_Decepticons.Tables[0].Rows[i][11].ToString()) > Int32.Parse(ds_Autobots.Tables[0].Rows[i][11].ToString()))
                {
                    numberOfWinsDecepticons = numberOfWinsDecepticons + 1;
                    numberOfLosesAutobots = numberOfLosesAutobots + 1;
                    numberOfTiesAutobots = numberOfTiesAutobots + 0;
                    numberOfTiesDecepticons = numberOfTiesDecepticons + 0;

                    winningTeamDecepticons.Add(ds_Decepticons.Tables[0].Rows[i][1].ToString());
                    losingTeamsAutobots.Add(ds_Autobots.Tables[0].Rows[i][1].ToString());

                }//OverallRatingA = OveralRatingD
                else if (Int32.Parse(ds_Decepticons.Tables[0].Rows[i][11].ToString()) == Int32.Parse(ds_Autobots.Tables[0].Rows[i][11].ToString()))
                {
                    numberOfWinsDecepticons = numberOfWinsDecepticons + 0;
                    numberOfLosesAutobots = numberOfLosesAutobots + 0;
                    numberOfTiesAutobots = numberOfTiesAutobots + 1;
                    numberOfTiesDecepticons = numberOfTiesDecepticons + 1;

                    DestroyedTransformers.Add(ds_Decepticons.Tables[0].Rows[i][1].ToString());
                    DestroyedTransformers.Add(ds_Autobots.Tables[0].Rows[i][1].ToString());
                }
            }//end of for loop

            //**************************************************************************************
            //* Optimus Prime vs Optimus Prime / Optimus Prime vs Predaking / Predaking vs Predaking
            //**************************************************************************************
            if (specialRule == true)
            {
                basicRules.Visible = false;
                specialRules.Visible = true;
            }
            //**************************************************************************************
            //* Autobots win and Decepticons have more team members (survivors)
            //**************************************************************************************
            else if ((numbattles > 0) && (numberOfWinsAutobots > numberOfWinsDecepticons))
            {
                tie.Visible = false;
                tie2.Visible = false;
                AutobotsWin.Visible = true;
                decepticonsWin.Visible = false;

                lblNumBattles.Text = numbattles.ToString();
                lblBattles.Text = (numbattles > 1 ? " Battles" : " Battle");
                lbl_AutobotWinners.Text = string.Join(",", winningTeamAutobots.Cast<string>());
                if (DecepticonsSurvivors.Count > 0)
                {
                    DecepticonSurvivors.Visible = true;
                    lbl_DecepticonSurvivors.Text = string.Join(",", DecepticonsSurvivors.Cast<string>());
                }

            }
            //**************************************************************************************
            //* Decepticons win and Autobots have more team members  (survivors)
            //**************************************************************************************
            else if ((numbattles > 0) && (numberOfWinsDecepticons > numberOfWinsAutobots))
            {
                tie.Visible = false;
                tie2.Visible = false;
                decepticonsWin.Visible = true;
                AutobotsWin.Visible = false;
                tie.Visible = false;

                lblnumberBattles.Text = numberbattles.ToString();
                lbl_Battles.Text = (numberbattles > 1 ? " Battles" : " Battle");
                lbl_DecepticonWinners.Text = string.Join(",", winningTeamDecepticons.Cast<string>());
                if (AutobotsSurvivors.Count > 0)
                {
                    AutobotSurvivors.Visible = true;
                    lbl_AutobotSurvivors.Text = string.Join(",", AutobotsSurvivors.Cast<string>());
                }
            }
            //**************************************************************************************
            //* Autobots and Decepticons TIE and Autobots have more team members  (survivors)
            //**************************************************************************************
            else if ((numbattles > 0) && (numberOfWinsAutobots == numberOfWinsDecepticons) && (DestroyedTransformers.Count == 0))
            {
                tie.Visible = true;
                tie2.Visible = false;
                decepticonsWin.Visible = false;
                AutobotsWin.Visible = false;

                lbl_numberBattles.Text = number_battles.ToString();
                lblnumberBattle.Text = (number_battles > 1 ? " Battles" : " Battle");

                lbl_Autobots_Winners.Text = string.Join(",", winningTeamAutobots.Cast<string>());
                if (AutobotsSurvivors.Count > 0)
                {
                    AutobotSurvivors.Visible = true;
                    lbl_Autobots_Survivors.Text = string.Join(",", AutobotsSurvivors.Cast<string>());
                }

                lbl_Decepticons_Survivors.Text = string.Join(",", winningTeamDecepticons.Cast<string>());
                if (DecepticonsSurvivors.Count > 0)
                {
                    DecepticonSurvivors.Visible = true;
                    lbl_Decepticons_Survivors.Text = string.Join(",", DecepticonsSurvivors.Cast<string>());
                }
            }
            //**************************************************************************************
            //*Speical Case, displays the destroyed transformers
            //**************************************************************************************
            else if ((numbattles > 0) && (numberOfWinsAutobots == numberOfWinsDecepticons) && (DestroyedTransformers.Count > 0))
            {                
                tie2.Visible = true;           
                lblDestroyedTransformers.Text = string.Join(",", DestroyedTransformers.Cast<string>());
            }
        }

        //**************************************************************************************
        //* Start a new battle by deleting all contents of database and starting fresh
        //**************************************************************************************
        protected void btn_StartNewGame_Click(object sender, EventArgs e)
        {
            //**************************************************************************************
            //* finally Delete all rows from the datatable
            //**************************************************************************************
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from Transformers", con);
            cmd.ExecuteNonQuery();
            con.Close();

            //**************************************************************************************
            //* Refresh to web page for a new game
            //**************************************************************************************
            Response.Redirect(Request.RawUrl);

        }
    }
}