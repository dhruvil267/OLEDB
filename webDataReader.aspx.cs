using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

namespace OLEDB
{
    public partial class webDataReader : System.Web.UI.Page
    {
        static OleDbConnection myCon;
        OleDbCommand myCmd;
        OleDbDataReader rdStudents;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {



                myCon = new OleDbConnection(@"Provider = Microsoft.Jet.OLEDB.4.0; Data Source =" + Server.MapPath("~/App_Data/College.mdb"));
                myCon.Open();

                myCmd = new OleDbCommand("select RefCourse, [Number] from Courses order by [Number]", myCon);
                rdStudents = myCmd.ExecuteReader();

                lstCourse.DataTextField = "Number";
                lstCourse.DataValueField = "RefCourse";
                lstCourse.DataSource = rdStudents;
                lstCourse.DataBind();

                string sql = "select * from courses where teacher =@teach and duration  <@dur";
                OleDbCommand myCmdTest = new OleDbCommand(sql, myCon);
                OleDbParameter myPar = new OleDbParameter("teach", "Houria Houmel");
                myPar.DbType = System.Data.DbType.String;
                myCmdTest.Parameters.Add(myPar);
                myCmdTest.Parameters.AddWithValue("dur", 50);
                OleDbDataReader rdTest = myCmdTest.ExecuteReader();
                gridTest.DataSource = rdTest;
                gridTest.DataBind();
            }



        }

        protected void lstCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            myCmd = new OleDbCommand("Select * from courses where refcourse=@ref", myCon);
            myCmd.Parameters.AddWithValue("ref", lstCourse.SelectedItem.Value);
            rdStudents = myCmd.ExecuteReader();
            if (rdStudents.Read())
            {
                txtNumber.Text = rdStudents["Number"].ToString();
                txtTitle.Text = rdStudents["Title"].ToString();
                txtDuration.Text = rdStudents["Duration"].ToString();
                txtTeacher.Text = rdStudents["Teacher"].ToString();
                txtDescription.Text = rdStudents["Description"].ToString();

            }
            rdStudents.Close();
            myCmd.CommandText = "Select StudentName as [Names],BirthDate as [Birth Dates], Telephone,Average,Email from Students where refercourse=@ref";
            rdStudents = myCmd.ExecuteReader();
            gridResult.DataSource = rdStudents;
            gridResult.DataBind();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int refc = Convert.ToInt32(lstCourse.SelectedItem.Value);
            string sql = "update courses set duration=@dur,teacher=@tea,description=@des where refcourse=@courseid";
            OleDbCommand myCmd = new OleDbCommand(sql, myCon);
            myCmd.Parameters.AddWithValue("dur",Convert.ToInt32(txtDuration.Text));
            myCmd.Parameters.AddWithValue("tea", txtTeacher.Text);
            myCmd.Parameters.AddWithValue("des",txtDescription.Text);
            myCmd.Parameters.AddWithValue("courseid", refc);
            int result = myCmd.ExecuteNonQuery();
            Response.Write("<script>alert(\"Updated\");</script>");
        }
    }
}