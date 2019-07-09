using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        initData("");
    }
    public void initData(string str)
    {
        string connstr = ConfigurationManager.AppSettings["connstr"].ToString();
        SqlConnection conn = new SqlConnection(connstr);
        conn.Open();
        string sql = "select * from t_teacher";
        if (str!="" && str !=null)
        {
            sql += " where " + str;
        }
        SqlCommand comm = new SqlCommand(sql, conn);
        SqlDataReader reader=comm.ExecuteReader();
        GridView1.DataSource = reader;
        GridView1.DataBind();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string whereStr = txtName.Text.Trim();
        initData("teacherName like '%"+whereStr+"%'");
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)//判定当前的行是否属于datarow类型的行
        {
            bool bsex = Convert.ToBoolean(e.Row.Cells[3].Text.ToString());            
            if (bsex == true)
                e.Row.Cells[3].Text = "男";
            else
                e.Row.Cells[3].Text = "女";
            string str = e.Row.Cells[5].Text;
            int len = str.Length;
            //if (len>5)
            //{
            //    str = str.Substring(0, 5) + "...";
            //}
            //e.Row.Cells[5].Text = str;
          if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState==DataControlRowState.Alternate)
        {
            ((LinkButton)e.Row.Cells[7].Controls[0]).Attributes.Add("onclick","javascript:return confirm('你确认要删除:\""+e.Row.Cells[2].Text+"\"?')");
        }      
        
        }


    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int index = e.RowIndex;
        string id = GridView1.DataKeys[index].Value.ToString();
        string connstr = ConfigurationManager.AppSettings["connstr"].ToString();
        SqlConnection conn = new SqlConnection(connstr);
        conn.Open();
        string sql = "delete from t_teacher where id="+id;
        SqlCommand comm = new SqlCommand(sql, conn);
        int n = comm.ExecuteNonQuery();
        initData("");
    }
}