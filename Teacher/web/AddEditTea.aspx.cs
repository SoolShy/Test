using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class AddEditTea : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            string id =Convert.ToString(Request.QueryString["id"]);
            if (id !=""&&id!=null)
            {
                initEditData(id);
            }
        }
           
        }
    public void initEditData(string id)
    {
        
        string connstr = ConfigurationManager.AppSettings["connstr"].ToString();
        SqlConnection conn = new SqlConnection(connstr);
        string sql = "select * from t_teacher where id=" + id;
        conn.Open();
        SqlCommand comm = new SqlCommand(sql, conn);
        SqlDataReader reader = comm.ExecuteReader();
        if (reader.Read())
        {
            lblId.Text = reader["id"].ToString();
            txtTeacherId.Text = reader["teacherId"].ToString();
            txtTeacherName.Text = reader["teacherName"].ToString();
            DateTime dt = Convert.ToDateTime(reader["birthday"]);
            txtBirthday.Text = dt.Date.ToString("yyyy-MM-dd");
            txtEmail.Text = reader["Email"].ToString();
            bool isSex = Convert.ToBoolean(reader["sex"]);
            if (isSex == true)

                rdoMale.Checked = true;
            else
                rdoFemale.Checked = true;
        }
        reader.Close();
        conn.Close();
}
    
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string teacherid = txtTeacherId.Text.Trim();
        string teachername = txtTeacherName.Text.Trim();
        string birthday = txtBirthday.Text.Trim();
        string email = txtEmail.Text.Trim();
        string sex="0";
        if (rdoMale.Checked == true)
            sex = "1";
        string connstr = ConfigurationManager.AppSettings["connstr"].ToString();
        SqlConnection conn = new SqlConnection(connstr);

        string id = Convert.ToString(Request.QueryString["id"]);
        string sql = "";
        if (id!=""&&id!=null)
        {
          sql = string.Format(@"UPDATE [teachers].[dbo].[t_teacher]
               SET [teacherId] = '{0}'
                  ,[teacherName] = '{1}'
                  ,[sex] = '{2}'
                  ,[birthday] ='{3}'
                  ,[Email] = '{4}'
             WHERE id={5}", teacherid, teachername, sex, birthday, email,id);
            }
        else  
        {

            sql = string.Format(@"INSERT INTO [teachers].[dbo].[t_teacher]
           ([teacherId],[teacherName],[sex],[birthday],[Email])
           VALUES ('{0}','{1}',{2},'{3}','{4}')",
           teacherid, teachername, sex, birthday, email);
        }


        conn.Open();
        SqlCommand comm = new SqlCommand(sql, conn);
        int n=comm.ExecuteNonQuery();
        conn.Close();
        if (n > 0)
        {
            Response.Write("<script>alert('数据保存成功')</script>");
            Response.Redirect("Default.aspx");
        }
        else
            Response.Write("<script>alert('数据保存失败')</script>");        
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtTeacherId.Text = txtTeacherName.Text = txtBirthday.Text = txtEmail.Text = "";
        rdoMale.Checked = true;
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
}