using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OLEDB
{

    public partial class webCollege : System.Web.UI.Page
    {
        static OleDbConnection myCon;
        OleDbCommand myCmd;
        OleDbDataReader rdSchool;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {



                myCon = new OleDbConnection(@"Provider = Microsoft.Jet.OLEDB.4.0; Data Source =" + Server.MapPath("~/App_Data/College2.mdb"));
                myCon.Open();

                myCmd = new OleDbCommand("select Refschool, Title from Schools order by title", myCon);
                rdSchool= myCmd.ExecuteReader();
                radlistSchool.DataTextField = "Title";
                
                radlistSchool.DataValueField = "Refschool";
                radlistSchool.DataSource = rdSchool;
                radlistSchool.DataBind();
                panCourse.Visible = false;
                panPrograms.Visible = false;

               
            }
        }

        protected void radlistSchool_SelectedIndexChanged(object sender, EventArgs e)
        {
            myCmd = new OleDbCommand("Select refProgram,title from programs where referschool=@ref", myCon);
            myCmd.Parameters.AddWithValue("ref", radlistSchool.SelectedItem.Value);
            rdSchool = myCmd.ExecuteReader();
            radlstPrograms.DataTextField = "Title";

            radlstPrograms.DataValueField = "RefProgram";
            radlstPrograms.DataSource = rdSchool;
            radlstPrograms.DataBind();
            panPrograms.Visible = true;


        }

        protected void radlstPrograms_SelectedIndexChanged(object sender, EventArgs e)
        {
            myCmd = new OleDbCommand("select RefCourse, [Number] from Courses where referProgram=@refpr", myCon);
            myCmd.Parameters.AddWithValue("refpr", radlstPrograms.SelectedItem.Value);

            rdSchool = myCmd.ExecuteReader();
            chklstCourses.DataTextField = "Number";

            chklstCourses.DataValueField = "RefCourse";
            chklstCourses.DataSource = rdSchool;
            chklstCourses.DataBind();
            panCourse.Visible = true;

        }

        protected void chklstCourses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(chklstCourses.SelectedIndex > -1)
            {
                string sql = "select studentname as [Names], Birthdate as [Birth Dates], Telephone, Average,Email from Students Where ReferCourse="+chklstCourses.SelectedItem.Value;
                foreach(ListItem item in chklstCourses.Items)
                {
                    if (item.Selected)
                    {
                        sql += " or ReferCourse=" + item.Value;
                    }
                }
                sql += " order by studentname";
                myCmd = new OleDbCommand(sql, myCon);
                rdSchool = myCmd.ExecuteReader();
                gridStudents.DataSource = rdSchool;
                gridStudents.DataBind();

            }
            else
            {
                gridStudents.DataSource = null;
                gridStudents.DataBind();
            }



        }

        protected void gridStudents_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}